using MediatR;
using Vehicle.Domain.Entities;

namespace Vehicle.Application.Queries.Veiculos;

public record ListarVeiculosQuery : IRequest<IEnumerable<Veiculo>>;
