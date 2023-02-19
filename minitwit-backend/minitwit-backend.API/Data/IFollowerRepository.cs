namespace minitwit_backend.Data;

public interface IFollowerRepository : IDisposable
{
    public void UnFollow(int fromId, int toId);
    public void Follow(int fromId, int toId);
}