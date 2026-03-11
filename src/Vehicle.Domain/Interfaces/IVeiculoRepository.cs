using Vehicle.Domain.Entities;

namespace Vehicle.Domain.Interfaces;

public interface IVeiculoRepository
{
    Task<Veiculo?> ObterPorIdAsync(int id);
    Task<IEnumerable<Veiculo>> ListarAsync();
    Task AdicionarAsync(Veiculo veiculo);
    Task AtualizarAsync(Veiculo veiculo);
    Task ExcluirAsync(int id);
}
