using Microsoft.EntityFrameworkCore;
using Vehicle.Domain.Entities;
using Vehicle.Domain.Interfaces;
using Vehicle.Infrastructure.Data;

namespace Vehicle.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly VehicleDbContext _context;

    public UsuarioRepository(VehicleDbContext context) => _context = context;

    public async Task<Usuario?> ObterPorIdAsync(int id) => await _context.Usuarios.FindAsync(id);

    public async Task<Usuario?> ObterPorLoginAsync(string login) => 
        await _context.Usuarios.FirstOrDefaultAsync(u => u.Login == login);

    public async Task<IEnumerable<Usuario>> ListarAsync() => await _context.Usuarios.ToListAsync();

    public async Task AdicionarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var usuario = await ObterPorIdAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
