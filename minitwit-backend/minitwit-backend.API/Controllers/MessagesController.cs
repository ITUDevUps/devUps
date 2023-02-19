using Microsoft.AspNetCore.Mvc;
using minitwit_backend.Data;
using minitwit_backend.Data.Model;

namespace minitwit_backend.Controllers;

[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageRepository _repo;

    public MessagesController(IMessageRepository repo)
    {
        _repo = repo;
    }

    [Route("GetMessages")]
    [HttpGet]
    public async Task<ActionResult<List<TwitDTO>>> GetMessages()
    {
        return await _repo.GetMessagesAsync();
    }

    [HttpGet("GetMessages/{userName}")]
    public async Task<ActionResult<List<TwitDTO>>> GetMessagesFromUser(string userName)
    {
        return await _repo.GetMessagesAsyncByUserName(userName);
    }
}