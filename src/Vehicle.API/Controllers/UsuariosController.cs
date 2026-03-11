using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Application.Commands.Usuarios;
using Vehicle.Application.Queries.Usuarios;

namespace Vehicle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Adicionar([FromBody] AdicionarUsuarioCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(ObterPorId), new { id }, new { id });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var usuario = await _mediator.Send(new ObterUsuarioPorIdQuery(id));
        if (usuario == null) return NotFound();

        return Ok(new { usuario.Id, usuario.Nome, usuario.Login });
    }
}
