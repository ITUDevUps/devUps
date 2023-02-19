using minitwit_backend.Data.Model;

namespace minitwit_backend.Data;

public interface IUserRepository : IDisposable
{
    public Task RegisterUser(ApiSimUser apiSimUser);
    public bool TryGetUserId(string username, out int id);
}