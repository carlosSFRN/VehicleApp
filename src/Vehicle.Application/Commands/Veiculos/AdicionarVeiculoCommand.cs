using MediatR;
using Vehicle.Domain.Enums;

namespace Vehicle.Application.Commands.Veiculos;

public record AdicionarVeiculoCommand(string Descricao, Marca Marca, string Modelo, string? Opcionais, decimal? Valor) : IRequest<int>;
