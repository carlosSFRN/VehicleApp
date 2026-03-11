using MediatR;
using Vehicle.Domain.Entities;

namespace Vehicle.Application.Queries.Veiculos;

public record ObterVeiculoPorIdQuery(int Id) : IRequest<Veiculo?>;
