using MediatR;
using Vehicle.Application.Commands.Veiculos;
using Vehicle.Domain.Entities;
using Vehicle.Domain.Interfaces;

namespace Vehicle.Application.Handlers.Veiculos;

public class AdicionarVeiculoHandler : IRequestHandler<AdicionarVeiculoCommand, int>
{
    private readonly IVeiculoRepository _repository;

    public AdicionarVeiculoHandler(IVeiculoRepository repository) => _repository = repository;

    public async Task<int> Handle(AdicionarVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculo = new Veiculo
        {
            Descricao = request.Descricao,
            Marca = request.Marca,
            Modelo = request.Modelo,
            Opcionais = request.Opcionais,
            Valor = request.Valor
        };

        await _repository.AdicionarAsync(veiculo);
        return veiculo.Id;
    }
}
