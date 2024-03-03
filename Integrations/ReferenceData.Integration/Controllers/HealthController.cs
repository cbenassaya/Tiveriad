#region

using Microsoft.AspNetCore.Mvc;

#endregion

namespace ReferenceData.Integration.Controllers;

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