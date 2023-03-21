using Microsoft.EntityFrameworkCore;
using minitwit_backend.Data.Model;

namespace minitwit_backend.Data
{
    public class MessageRepository : IMessageRepository
    {
        private MinitwitContext _context;

        public MessageRepository(MinitwitContext context) { 
            _context = context;
        }

        public Task<List<TwitDTO>> GetMessagesAsync()
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

        public Task<List<TwitDTO>> GetMessagesAsync(DateTime date, int page)
        {
            return _context
                .Messages
                .OrderByDescending(x => x.Date)
                .Where(x => x.Date <= date)
                .Skip(page * 40)
                .Take(40)
                .Join(
                    _context.Users,
                    messages => messages.AuthorId,
                    users => users.UserId,
                    (message, user) => new TwitDTO
                    {
                        UserName = user.Username,
                        Message = message.Text,
                        DateTime = message.Date
                    })
                .ToListAsync();
        }

        public Task<List<TwitDTO>> GetMessagesAsyncByUserName(string userName)
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

        public async Task PostMessageAsync(TwitDTO tweet, int authorId)
        {
            await _context.AddAsync(new Message
            {
                AuthorId = authorId,
                PubDate = tweet.Date,
                Text = tweet.Message,
            });
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
