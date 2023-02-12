using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace minitwit_backend.Data
{
    internal class MessageRepository
    {

        private readonly MinitwitContext _context;

        public MessageRepository(MinitwitContext context) { 
            _context = context;
        }

        internal async static Task<List<TwitDTO>> GetMessagesAsync() 
        {
            using (var db = new MinitwitContext())
            {
                var query =
                    from message in db.Messages
                    join user in db.Users on message.AuthorId equals user.UserId
                    orderby message.MessageId
                    select new TwitDTO
                    {
                        UserName = user.Username,
                        Message = message.Text,
                        Date = message.PubDate
                    };
                return query.Reverse<TwitDTO>().Take(30).ToList();
            }
        
        }


    }
}
