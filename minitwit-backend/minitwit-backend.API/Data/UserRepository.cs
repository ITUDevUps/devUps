using System.Data.Entity;
using minitwit_backend.Data.Model;

namespace minitwit_backend.Data
{
    public class UserRepository : IUserRepository
    {
        private MinitwitContext _context;

        public UserRepository(MinitwitContext context)
        {
            _context = context;
        }

        public bool TryGetUserId(string username, out int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(username));

            id = -1;

            if (user != null)
            {
                id = user.UserId;
            }

            return id != -1;
        }

        public async Task RegisterUser(ApiSimUser apiSimUser)
        {
            var latestUserId = _context.Users.Max(x => x.UserId);

            await _context.AddAsync(new User
            {
                Email = apiSimUser.Email!,
                UserId = latestUserId + 1,
                Username = apiSimUser.UserName!,
                PwHash = apiSimUser.Password! //TODO Generate password hash
            });
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}