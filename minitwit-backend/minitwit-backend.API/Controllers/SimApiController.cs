﻿using Microsoft.AspNetCore.Mvc;
using minitwit_backend.Data;
using minitwit_backend.Data.Model;

namespace minitwit_backend.Controllers;

[Route("sim-api")]
[ApiController]
public class SimApiController : ControllerBase
{

    private readonly IMessageRepository _messageRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<SimApiController> _logger;


    private static int _latest = 0;

    public SimApiController(IUserRepository userRepository, IMessageRepository messageRepository, ILogger<SimApiController> logger)
    {
        _userRepository = userRepository;
        _messageRepository = messageRepository;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody]ApiSimUser user, [FromQuery] int? latest)
    {
        UpdateLatest(latest);

        _logger.LogInformation("SimAPI Register User", DateTime.UtcNow);

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
            else if (String.IsNullOrEmpty(user.pwd))
            {
                error = "You have to enter a password";
            }
            else
            {
                if (!_userRepository.TryGetUserId(user.UserName, out _))
                    await _userRepository.RegisterUser(user);
                else
                {
                    error = "The username is already taken";
                }
            }
        }
        catch (Exception e)
        {
            error = e.Message;
            _logger.LogError(error);
        }
        if (error != string.Empty)
        {
            _logger.LogError(error);
            return BadRequest(error);

        }

        return NoContent();
    }

    [HttpPost("fllws/{username}")]
    public async Task<IActionResult> FollowUser([FromRoute]string username, [FromBody]ApiSimFollow follow, [FromQuery] int? latest)
    {
        UpdateLatest(latest);

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
                    return NotFound(follow.Unfollow);
                }

                await _userRepository.Follow(userId, followId);
            }
            else if (!string.IsNullOrEmpty(follow.Unfollow))
            {
                if (!_userRepository.TryGetUserId(follow.Unfollow, out var unFollowId))
                {
                    return NotFound(follow.Unfollow);
                }

                await _userRepository.UnFollow(userId, unFollowId);
            }
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
        return NoContent();
    }

    [HttpGet("fllws/{username}")]
    public async Task<IActionResult> GetFollowUser([FromRoute] string username, [FromQuery] int? latest)
    {
        UpdateLatest(latest);

        try
        {
            if (!_userRepository.TryGetUserId(username, out var userId))
            {
                return NotFound(username);
            }

               return Ok(await _userRepository.GetFollowering(userId));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
        return NoContent();
    }



    [HttpPost("msgs/{username}")]
    public async Task<IActionResult> Tweet([FromRoute]string username, [FromBody]ApiSimTweet tweet, [FromQuery] int? latest)
    {
        UpdateLatest(latest);

        var error = string.Empty;
        try
        {
            if (_userRepository.TryGetUserId(username, out var userid))
            {
                await _messageRepository.PostMessageAsync(new TwitDTO
                {
                    UserName = username,
                    Date = (int)DateTime.UtcNow.Ticks,
                    Message = tweet.Content ?? string.Empty
                }, userid);
            }
            else
            {
                error = "user does not exist";
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

    [HttpGet("latest")]
    public async Task<ApiSimLatest> GetLatest()
    {
        return new ApiSimLatest { Latest = _latest };
    }

    private void UpdateLatest(int? latest)
    {
        if (latest != null)
        {
            _latest = latest.Value;
        }
    }
}