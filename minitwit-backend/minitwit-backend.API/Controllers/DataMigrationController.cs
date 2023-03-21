using Microsoft.AspNetCore.Mvc;
using minitwit_backend.Data;

namespace minitwit_backend.Controllers;

[Route("migrate")]
[ApiController]
public class DataMigrationController : ControllerBase
{
    private readonly IDataMigrationRepository _repo;

    public DataMigrationController(IDataMigrationRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("MigrateMessageDates")]
    public async Task<ActionResult<int>> GetMigrateMessageDates([FromQuery] int? amount)
    {
        return await _repo.TryUpdateMessageDate(amount ?? 100);
    }
}