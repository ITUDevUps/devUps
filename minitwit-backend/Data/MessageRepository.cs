using Microsoft.EntityFrameworkCore;

namespace minitwit_backend.Data
{
    internal class MessageRepository
    {

        private readonly MinitwitContext _context;

        public MessageRepository(MinitwitContext context) { 
            _context = context;
        }

        internal async static Task<List<Message>> GetMessagesAsync() 
        {
            using (var db = new MinitwitContext())
            {

                return await db.Messages.ToListAsync();
            }
        
        }


    }
}
