using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using minitwit_backend.Data;
using minitwit_backend.Data.Model;

namespace minitwit_backend.Test
{
    public class TestContext : IDisposable
    {
        private SqliteConnection _connection;
        private MinitwitContext _dbContext;
        internal MessageRepository Repo;

        public TestContext()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();

            var option = new DbContextOptionsBuilder<MinitwitContext>()
                .UseSqlite(_connection)
                .Options;
            _dbContext = new MinitwitContext(option);
            Repo = new MessageRepository(_dbContext);
            _dbContext.Database.EnsureCreated();
        }

        public async Task<TestContext> SetupMessageRepo()
        {
            User user = new User
            {
                UserId = 1234,
                Username = "Test",
                Email = "test@test.com",
                PwHash = "1234"
            };
            Message msg = new Message
            {
                MessageId = 1234,
                AuthorId = 1234,
                Text = "I'm a test"
            };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.Messages.AddAsync(msg);
            await _dbContext.SaveChangesAsync();
            return this;
        }

        public void Dispose()
        {
            _connection.Close();
            _dbContext.Dispose();
        }
    }
}