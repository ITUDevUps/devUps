using Microsoft.AspNetCore.Mvc;
using minitwit_backend.Data;
using minitwit_backend.Data.Model;

namespace minitwit_backend.Controllers;

[Route("api-sim")]
[ApiController]
public class SimApiController : ControllerBase
{
    private readonly IMessageRepository _messageRepo;
    private readonly IUserRepository _userRepository;
    private readonly IFollowerRepository _followerRepository;

    public SimApiController(IMessageRepository messageRepo, IUserRepository userRepository, IFollowerRepository followerRepository)
    {
        _messageRepo = messageRepo;
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
            return new BadRequestResult();
        }

        return new NoContentResult();
    }

    public static WebApplication SimApiEndpoint(WebApplication app)
    {
        app.MapPost("/api-sim/fllws/{username}", (string username, ApiSimFollow follow) =>
        {
            try
            {
                var context = new MinitwitContext();

                using var userRepo = new UserRepository(context);

                if (!userRepo.TryGetUserId(username, out var userId))
                {
                    return Results.NotFound(username);
                }

                if (!string.IsNullOrEmpty(follow.Follow))
                {
                    if (!userRepo.TryGetUserId(follow.Follow, out var followId))
                    {
                        return Results.NotFound(follow.UnFollow);
                    }

                    using var followerRepo = new FollowerRepository(context);
                    followerRepo.Follow(userId, followId);
                }
                else if (!string.IsNullOrEmpty(follow.UnFollow))
                {
                    if (!userRepo.TryGetUserId(follow.UnFollow, out var unFollowId))
                    {
                        return Results.NotFound(follow.UnFollow);
                    }

                    using var followerRepo = new FollowerRepository(context);
                    followerRepo.Follow(userId, unFollowId);
                }
            }
            catch (Exception e)
            {
                return Results.NotFound(e);
            }
            return Results.NoContent();
        });
        return app;
    }
}
