using minitwit_backend.Data.Model;

namespace minitwit_backend.Data;

public interface IUserRepository : IDisposable
{
    public Task RegisterUser(RegisterUserDTO user);
    public Task RegisterUser(ApiSimUser apiSimUser);

    public Task<int> VerifyLogin(UserLoginDTO userLoginDTO);
    public bool TryGetUserId(string username, out int id);

    internal Task<List<UserDTO>> GetUsersAsync();
}