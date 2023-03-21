using System.Data.Entity;
using minitwit_backend.Data.Model;

namespace minitwit_backend.Data;

public class DataMigrationRepository : IDataMigrationRepository
{
    private MinitwitContext _context;

    public DataMigrationRepository(MinitwitContext context)
    {
        _context = context;
    }

    public async Task<int> TryUpdateMessageDate(int amount = 100)
    {
        var missingDate = await _context
            .Messages
            .Where(x => x.Date == null)
            .Take(amount)
            .Select(x => new Message
            {
                MessageId = x.MessageId,
                AuthorId = x.AuthorId,
                Text = x.Text,
                Date = DateTime.UtcNow,
                PubDate = null,
                Flagged = x.Flagged
            })
            .ToListAsync();

        if (missingDate.Any())
        {
            await _context.AddRangeAsync(missingDate);
        }

        var hasBoth = await _context
            .Messages
            .Where(x => x.Date != null && x.PubDate != null)
            .Take(amount)
            .Select(x => new Message
            {
                MessageId = x.MessageId,
                AuthorId = x.AuthorId,
                Text = x.Text,
                Date = x.Date,
                PubDate = null,
                Flagged = x.Flagged
            })
            .ToListAsync();

        if (hasBoth.Any())
        {
            await _context.AddRangeAsync(hasBoth);
        }

        await _context.SaveChangesAsync();
        return missingDate.Count + hasBoth.Count;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}