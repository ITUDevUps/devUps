using minitwit_backend.Data.Model;

namespace minitwit_backend.Data;

public interface IMessageRepository : IDisposable
{
    internal Task<List<TwitDTO>> GetMessagesAsync();
    internal Task<List<TwitDTO>> GetMessagesAsync(DateTime date, int page);
    internal Task<List<TwitDTO>> GetMessagesAsyncByUserName(string userName);
    internal Task PostMessageAsync(TwitDTO tweet, int authorId);
}