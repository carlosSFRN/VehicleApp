using MediatR;
using Vehicle.Application.Queries.Usuarios;
using Vehicle.Domain.Entities;
using Vehicle.Domain.Interfaces;

namespace Vehicle.Application.Handlers.Usuarios;

public class ObterUsuarioPorIdHandler : IRequestHandler<ObterUsuarioPorIdQuery, Usuario?>
{
    private readonly IUsuarioRepository _repository;

    public ObterUsuarioPorIdHandler(IUsuarioRepository repository) => _repository = repository;

    public async Task<Usuario?> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken) =>
        await _repository.ObterPorIdAsync(request.Id);
}
