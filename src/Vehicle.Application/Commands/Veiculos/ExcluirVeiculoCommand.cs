using MediatR;

namespace Vehicle.Application.Commands.Veiculos;

public record ExcluirVeiculoCommand(int Id) : IRequest<bool>;
