using Microsoft.EntityFrameworkCore;
using minitwit_backend.Data.Model;

namespace minitwit_backend.Data
{
    public class UserRepository : IDisposable
    {
        private MinitwitContext _context;

        public UserRepository(MinitwitContext context)
        {
            _context = context;
        }

        public bool TryGetUserId(string username, out int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(username));

            if (user != null)
            {
                id = user.UserId;
            }

            id = -1;
            return id != -1;
        }

        public async void RegisterUser(ApiSimUser apiSimUser)
        {
            var latestUserId = _context.Users.Max(x => x.UserId);

            _context.Add(new User
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