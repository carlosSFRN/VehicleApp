using Microsoft.EntityFrameworkCore;
using Vehicle.Domain.Entities;
using Vehicle.Domain.Interfaces;
using Vehicle.Infrastructure.Data;

namespace Vehicle.Infrastructure.Repositories;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly VehicleDbContext _context;

    public VeiculoRepository(VehicleDbContext context) => _context = context;

    public async Task<Veiculo?> ObterPorIdAsync(int id) => await _context.Veiculos.FindAsync(id);

    public async Task<IEnumerable<Veiculo>> ListarAsync() => await _context.Veiculos.ToListAsync();

    public async Task AdicionarAsync(Veiculo veiculo)
    {
        await _context.Veiculos.AddAsync(veiculo);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Veiculo veiculo)
    {
        _context.Veiculos.Update(veiculo);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var veiculo = await ObterPorIdAsync(id);
        if (veiculo != null)
        {
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
