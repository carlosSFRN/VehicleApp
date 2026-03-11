using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Application.Commands.Usuarios;

namespace Vehicle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator) => _mediator = mediator;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var token = await _mediator.Send(command);
        if (token == null) return Unauthorized(new { message = "Login ou senha inválidos" });

        return Ok(new { token });
    }
}
