using MediatR;
using Vehicle.Application.Queries.Veiculos;
using Vehicle.Domain.Entities;
using Vehicle.Domain.Interfaces;

namespace Vehicle.Application.Handlers.Veiculos;

public class ListarVeiculosHandler : IRequestHandler<ListarVeiculosQuery, IEnumerable<Veiculo>>
{
    private readonly IVeiculoRepository _repository;

    public ListarVeiculosHandler(IVeiculoRepository repository) => _repository = repository;

    public async Task<IEnumerable<Veiculo>> Handle(ListarVeiculosQuery request, CancellationToken cancellationToken) =>
        await _repository.ListarAsync();
}
