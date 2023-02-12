using Microsoft.EntityFrameworkCore;

namespace minitwit_backend.Data
{
    internal class MessageRepository : IDisposable
    {
        private MinitwitContext _context;

        public MessageRepository(MinitwitContext context) { 
            _context = context;
        }

        internal async Task<List<TwitDTO>> GetMessagesAsync()
        {
            var query =
                from message in _context.Messages
                join user in _context.Users on message.AuthorId equals user.UserId
                orderby message.MessageId
                select new TwitDTO
                {
                    UserName = user.Username,
                    Message = message.Text,
                    Date = message.PubDate
                };
            return query.Reverse<TwitDTO>().Take(30).ToList();
        }

        internal async Task<List<TwitDTO>> GetMessagesAsyncByUserName(string userName)
        {
            var query =
                from message in _context.Messages
                join user in _context.Users on message.AuthorId equals user.UserId
                where user.Username == userName
                orderby message.MessageId
                select new TwitDTO
                {
                    UserName = user.Username,
                    Message = message.Text,
                    Date = message.PubDate
                };
            return query.Reverse<TwitDTO>().Take(30).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
