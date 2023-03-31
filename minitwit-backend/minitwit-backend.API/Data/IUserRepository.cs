using minitwit_backend.Data.Model;

namespace minitwit_backend.Data;

public interface IUserRepository : IDisposable
{
    public Task RegisterUser(RegisterUserDTO user);
    public Task RegisterUser(ApiSimUser apiSimUser);

    public Task<UserDTO?> VerifyLogin(UserLoginDTO userLoginDTO);
    public bool TryGetUserId(string username, out int id);

    public Task<List<UserDTO>> GetUsersAsync();
    public Task UnFollow(int fromId, int toId);
    public Task Follow(int fromId, int toId);

    public Task<APISimFollowing> GetFollowering(int userId);
}