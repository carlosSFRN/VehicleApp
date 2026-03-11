using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Application.Commands.Veiculos;
using Vehicle.Application.Queries.Veiculos;

namespace Vehicle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VeiculosController : ControllerBase
{
    private readonly IMediator _mediator;

    public VeiculosController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Adicionar([FromBody] AdicionarVeiculoCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(ObterPorId), new { id }, new { id });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarVeiculoCommand command)
    {
        if (id != command.Id) return BadRequest();

        var sucesso = await _mediator.Send(command);
        if (!sucesso) return NotFound();

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var veiculo = await _mediator.Send(new ObterVeiculoPorIdQuery(id));
        if (veiculo == null) return NotFound();

        return Ok(veiculo);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var veiculos = await _mediator.Send(new ListarVeiculosQuery());
        return Ok(veiculos);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Excluir(int id)
    {
        var sucesso = await _mediator.Send(new ExcluirVeiculoCommand(id));
        if (!sucesso) return NotFound();

        return NoContent();
    }
}
