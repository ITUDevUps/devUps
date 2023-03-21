using minitwit_backend.Data.Model;

namespace minitwit_backend.Data;

public interface IUserRepository : IDisposable
{
    public Task RegisterUser(RegisterUserDto user);
    public Task RegisterUser(ApiSimUser apiSimUser);

    public Task<int> VerifyLogin(UserLoginDto userLoginDto);
    public bool TryGetUserId(string username, out int id);

    public Task<List<UserDto>> GetUsersAsync();
    public Task UnFollow(int fromId, int toId);
    public Task Follow(int fromId, int toId);

    public Task<ApiSimFollowing> GetFollowering(int userId);
}