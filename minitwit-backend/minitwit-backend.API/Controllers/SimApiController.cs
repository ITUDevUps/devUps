using Microsoft.AspNetCore.Mvc;
using minitwit_backend.Data;
using minitwit_backend.Data.Model;

namespace minitwit_backend.Controllers;

[Route("sim-api")]
[ApiController]
public class SimApiController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IFollowerRepository _followerRepository;

    public SimApiController(IUserRepository userRepository, IFollowerRepository followerRepository)
    {
        _userRepository = userRepository;
        _followerRepository = followerRepository;
    }

    [HttpPost("register")]
    public IActionResult RegisterUser(ApiSimUser user)
    {
        var error = string.Empty;
        try
        {
            if (String.IsNullOrEmpty(user.UserName))
            {
                error = "You have to enter a username";
            }
            else if (String.IsNullOrEmpty(user.Email) || !user.Email.Contains('@'))
            {
                error = "You have to enter a valid email address";
            }
            else if (String.IsNullOrEmpty(user.Password))
            {
                error = "You have to enter a password";
            } //also needs to check if username exists
            else
            {
                _userRepository.RegisterUser(user);
            }
        }
        catch (Exception e)
        {
            error = e.Message;
        }
        if (error != string.Empty)
        {
            return BadRequest(error);
        }

        return NoContent();
    }

    [HttpPost("fllws/{username}")]
    public IActionResult FollowUser(string username, ApiSimFollow follow)
    {
        try
        {
            if (!_userRepository.TryGetUserId(username, out var userId))
            {
                return NotFound(username);
            }

            if (!string.IsNullOrEmpty(follow.Follow))
            {
                if (!_userRepository.TryGetUserId(follow.Follow, out var followId))
                {
                    return NotFound(follow.UnFollow);
                }

                _followerRepository.Follow(userId, followId);
            }
            else if (!string.IsNullOrEmpty(follow.UnFollow))
            {
                if (!_userRepository.TryGetUserId(follow.UnFollow, out var unFollowId))
                {
                    return NotFound(follow.UnFollow);
                }

                _followerRepository.Follow(userId, unFollowId);
            }
        }
        catch (Exception e)
        {
            return NotFound(e);
        }
        return NoContent();
    }
}
