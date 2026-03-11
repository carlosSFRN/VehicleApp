using MediatR;
using Vehicle.Domain.Enums;

namespace Vehicle.Application.Commands.Veiculos;

public record AtualizarVeiculoCommand(int Id, string Descricao, Marca Marca, string Modelo, string? Opcionais, decimal? Valor) : IRequest<bool>;
