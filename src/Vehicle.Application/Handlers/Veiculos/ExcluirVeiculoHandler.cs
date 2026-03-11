using MediatR;
using Vehicle.Application.Commands.Veiculos;
using Vehicle.Domain.Interfaces;

namespace Vehicle.Application.Handlers.Veiculos;

public class ExcluirVeiculoHandler : IRequestHandler<ExcluirVeiculoCommand, bool>
{
    private readonly IVeiculoRepository _repository;

    public ExcluirVeiculoHandler(IVeiculoRepository repository) => _repository = repository;

    public async Task<bool> Handle(ExcluirVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = await _repository.ObterPorIdAsync(request.Id);
        if (veiculo == null) return false;

        await _repository.ExcluirAsync(request.Id);
        return true;
    }
}
