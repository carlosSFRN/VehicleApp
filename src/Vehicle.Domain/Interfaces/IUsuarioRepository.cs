using Vehicle.Domain.Entities;

namespace Vehicle.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorIdAsync(int id);
    Task<Usuario?> ObterPorLoginAsync(string login);
    Task<IEnumerable<Usuario>> ListarAsync();
    Task AdicionarAsync(Usuario usuario);
    Task AtualizarAsync(Usuario usuario);
    Task ExcluirAsync(int id);
}
