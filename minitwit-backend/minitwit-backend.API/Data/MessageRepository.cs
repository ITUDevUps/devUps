using Microsoft.EntityFrameworkCore;

namespace minitwit_backend.Data
{
    internal class MessageRepository : IDisposable
    {
        private MinitwitContext _context;

        public MessageRepository(MinitwitContext context) { 
            _context = context;
        }

        internal  Task<List<TwitDTO>> GetMessagesAsync()
        {
            return _context.Messages
                .Join(
                    _context.Users,
                    messages => messages.AuthorId,
                    users => users.UserId,
                    (message, user) => new TwitDTO
                    {
                        UserName = user.Username,
                        Message = message.Text,
                        Date = message.PubDate
                    }).ToListAsync();
        }

        internal Task<List<TwitDTO>> GetMessagesAsyncByUserName(string userName)
        {
            return _context.Messages
                .OrderBy(x => x.MessageId)
                .Join(
                _context.Users,
                messages => messages.AuthorId,
                users => users.UserId,
                (message, user) => new TwitDTO
                {
                    UserName = user.Username,
                    Message = message.Text,
                    Date = message.PubDate
                })
                .Where(x => x.UserName.Equals(userName))
                .ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
