using minitwit_backend.Data.Model;

namespace minitwit_backend.Data
{
    public class FollowerRepository : IFollowerRepository
    {
        private MinitwitContext _context;

        public FollowerRepository(MinitwitContext context)
        {
            _context = context;
        }

        public async void Follow(int fromId, int toId)
        {
            await _context.AddAsync(new Follower
            {
                WhoId = fromId,
                WhomId = toId
            });

            await _context.SaveChangesAsync();
        }

        public async void UnFollow(int fromId, int toId)
        {
            throw new NotImplementedException("Not implemented");
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}