using MediatR;
using Vehicle.Application.Queries.Veiculos;
using Vehicle.Domain.Entities;
using Vehicle.Domain.Interfaces;

namespace Vehicle.Application.Handlers.Veiculos;

public class ObterVeiculoPorIdHandler : IRequestHandler<ObterVeiculoPorIdQuery, Veiculo?>
{
    private readonly IVeiculoRepository _repository;

    public ObterVeiculoPorIdHandler(IVeiculoRepository repository) => _repository = repository;

    public async Task<Veiculo?> Handle(ObterVeiculoPorIdQuery request, CancellationToken cancellationToken) =>
        await _repository.ObterPorIdAsync(request.Id);
}
