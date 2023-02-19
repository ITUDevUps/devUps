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

        public async Task Follow(int fromId, int toId)
        {
            await _context.AddAsync(new Follower
            {
                WhoId = fromId,
                WhomId = toId
            });

            await _context.SaveChangesAsync();
        }

        public async Task UnFollow(int fromId, int toId)
        {
            _context.Followers.Remove(new Follower
            {
                WhoId = fromId,
                WhomId = toId
            });
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}