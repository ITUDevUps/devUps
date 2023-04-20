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

    [HttpGet("GetMessages")]
    public async Task<ActionResult<List<TwitDTO>>> GetMessages([FromQuery] int? date = null, [FromQuery] int page = 0)
    {
        if (date != null)
        {
            return await _repo.GetMessagesAsync(date.Value, page);
        }

        return await _repo.GetMessagesAsync();
    }

    [HttpGet("GetMessages/{userName}")]
    public async Task<ActionResult<List<TwitDTO>>> GetMessagesFromUser(string userName)
    {
        return await _repo.GetMessagesAsyncByUserName(userName);
    }

    [HttpPost("PostMessage")]
    public async Task<ActionResult<TwitDTO>> PostMessage([FromBody] TwitDTO twit, int authorId)
    {
        await _repo.PostMessageAsync(twit, authorId);
        return Ok();
    }

}