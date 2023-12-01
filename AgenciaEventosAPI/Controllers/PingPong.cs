using Microsoft.AspNetCore.Mvc;

namespace AgenciaEventosAPI.Controllers;

//It's an test endpoint
[Route("api/ping")]
[ApiController]
public class PingPong : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok("pong");
    }
}