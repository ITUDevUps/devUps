using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
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

        public Task<List<UserDTO>> GetUsersAsync()
        {
            return _context.Users
                .Join(
                    _context.Users,
                    users => users.UserId,
                    users => users.UserId,
                    (user, user2) => new UserDTO
                    {
                        UserId = user.UserId,
                        UserName = user.Username
                    }).ToListAsync();
        }

        public async Task RegisterUser(ApiSimUser apiSimUser)
        {

            await _context.AddAsync(new User
            {
                Email = apiSimUser.Email!,
                Username = apiSimUser.UserName!,
                PwHash = apiSimUser.pwd! //TODO Generate password hash
            });
            await _context.SaveChangesAsync();
        }

        public async Task<int> VerifyLogin(UserLoginDTO userLoginDTO)
        {
            var userFromDatabase = await _context.Users.FirstOrDefaultAsync<User>(u => u.Username == userLoginDTO.UserName);

            if (userFromDatabase != null)
            {
                var salt = userFromDatabase.PwHash.Split(":")[0];
                var hash = userFromDatabase.PwHash.Split(":")[1];
                if (VerifyPassword(userLoginDTO.Password, hash, Convert.FromHexString(salt)))
                {
                    return userFromDatabase.UserId;
                }
                else
                {
                    return -1;
                };
            }
            return -1;
        }


        public async Task RegisterUser(RegisterUserDTO user)
        {

            var hashedPassword = HashPasword(user.Password, out var salt);

            await _context.AddAsync(new User
            {
                Email = user.Email!,
                Username = user.UserName!,
                PwHash = Convert.ToHexString(salt) + ":" + hashedPassword!
            });
            await _context.SaveChangesAsync();
        }

        public async Task Follow(int fromId, int toId)
        {
            var user = await _context
                .Users
                .Include(x => x.Following)
                .FirstOrDefaultAsync(x => x.UserId.Equals(fromId));

            var otherUser = await _context
                .Users
                .Include(x => x.Followers)
                .FirstOrDefaultAsync(x => x.UserId.Equals(toId));

            if (user == null || otherUser == null)
            {
                throw new ArgumentException();
            }

            if (user.Following.Contains(otherUser) || otherUser.Followers.Contains(user))
            {
                //Already Following
                return;
            }

            user.Following.Add(otherUser);
            otherUser.Followers.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task UnFollow(int fromId, int toId)
        {
            var user = await _context
                .Users
                .Include(x => x.Following)
                .FirstOrDefaultAsync(x => x.UserId.Equals(fromId));

            var otherUser = await _context
                .Users
                .Include(x => x.Followers)
                .FirstOrDefaultAsync(x => x.UserId.Equals(toId));

            if (user == null || otherUser == null)
            {
                throw new ArgumentException();
            }

            if (!user.Following.Contains(otherUser) || !otherUser.Followers.Contains(user))
            {
                //Already Following
                return;
            }

            user.Following.Remove(otherUser);
            otherUser.Followers.Remove(user);

            await _context.SaveChangesAsync();
        }


        //Util for hashing password and verifying

        const int keySize = 64;
        const int iterations = 20000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
        private string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }

        private bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }







        public void Dispose()
        {
            _context.Dispose();
        }


    }
}