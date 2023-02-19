namespace minitwit_backend.Data;

public interface IFollowerRepository : IDisposable
{
    public Task UnFollow(int fromId, int toId);
    public Task Follow(int fromId, int toId);
}