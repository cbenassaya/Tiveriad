using Microsoft.AspNetCore.Mvc;

namespace DataReference.Apis.Controllers;

public class HealthController : ControllerBase
{
    // GET
    [HttpGet("/api/health")]
    public async Task<ActionResult<string>> HandleAsync(
        CancellationToken cancellationToken)
    {
        return Ok("OK");
    }
}