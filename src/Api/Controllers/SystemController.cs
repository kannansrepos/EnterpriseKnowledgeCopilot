using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class SystemController : BaseApiController
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok(new
        {
            message = "API is running",
            utcTime = DateTime.UtcNow
        });
    }
}