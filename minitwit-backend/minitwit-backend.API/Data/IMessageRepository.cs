using minitwit_backend.Data.Model;

namespace minitwit_backend.Data;

public interface IMessageRepository : IDisposable
{
    internal Task<List<TwitDto>> GetMessagesAsync();
    internal Task<List<TwitDto>> GetMessagesAsyncByUserName(string userName);
    internal Task PostMessageAsync(TwitDto tweet, int authorId);
}