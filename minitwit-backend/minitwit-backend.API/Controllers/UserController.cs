using Microsoft.AspNetCore.Mvc;
using minitwit_backend.Data;
using minitwit_backend.Data.Model;

namespace minitwit_backend.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserDTO user)
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
            }
            else
            {
                if (!_userRepository.TryGetUserId(user.UserName, out _))
                    await _userRepository.RegisterUser(user);
                else
                    error = "Username already exists";
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

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(UserLoginDTO user)
    {
        string error;
        try
        {
            if (String.IsNullOrEmpty(user.UserName))
            {
                error = "You have to enter a username";
            }
            else if (String.IsNullOrEmpty(user.Password))
            {
                error = "You have to enter a password";
            }
            else
            {
                var verifiedUser = await _userRepository.VerifyLogin(user);
                if (verifiedUser.UserId != -1)
                {
                    return Ok(verifiedUser);
                }
                else
                {
                    error = "wrong password";
                }

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

    [HttpGet("GetUsers")]
    public async Task<ActionResult<List<UserDTO>>> GetUsers()
    {
        return await _userRepository.GetUsersAsync();
    }


}