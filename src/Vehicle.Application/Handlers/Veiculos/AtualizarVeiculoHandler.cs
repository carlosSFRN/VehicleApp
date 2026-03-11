using MediatR;
using Vehicle.Application.Commands.Veiculos;
using Vehicle.Domain.Interfaces;

namespace Vehicle.Application.Handlers.Veiculos;

public class AtualizarVeiculoHandler : IRequestHandler<AtualizarVeiculoCommand, bool>
{
    private readonly IVeiculoRepository _repository;

    public AtualizarVeiculoHandler(IVeiculoRepository repository) => _repository = repository;

    public async Task<bool> Handle(AtualizarVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = await _repository.ObterPorIdAsync(request.Id);
        if (veiculo == null) return false;

        veiculo.Descricao = request.Descricao;
        veiculo.Marca = request.Marca;
        veiculo.Modelo = request.Modelo;
        veiculo.Opcionais = request.Opcionais;
        veiculo.Valor = request.Valor;

        await _repository.AtualizarAsync(veiculo);
        return true;
    }
}
