using minitwit_backend.Data.Model;

namespace minitwit_backend.Data;

public interface IUserRepository : IDisposable
{
    public void RegisterUser(ApiSimUser apiSimUser);
    public bool TryGetUserId(string username, out int id);
}