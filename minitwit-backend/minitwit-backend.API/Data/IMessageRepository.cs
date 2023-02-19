using minitwit_backend.Data.Model;

namespace minitwit_backend.Data;

public interface IMessageRepository : IDisposable
{
    internal Task<List<TwitDTO>> GetMessagesAsync();
    internal Task<List<TwitDTO>> GetMessagesAsyncByUserName(string userName);
    internal Task PostMessage(TwitDTO tweet, int authorId);
}