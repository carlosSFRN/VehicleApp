using MediatR;
using Vehicle.Application.Commands.Usuarios;
using Vehicle.Application.Services;
using Vehicle.Domain.Entities;
using Vehicle.Domain.Interfaces;

namespace Vehicle.Application.Handlers.Usuarios;

public class AdicionarUsuarioHandler : IRequestHandler<AdicionarUsuarioCommand, int>
{
    private readonly IUsuarioRepository _repository;
    private readonly IAuthService _authService;

    public AdicionarUsuarioHandler(IUsuarioRepository repository, IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    public async Task<int> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = new Usuario
        {
            Nome = request.Nome,
            Login = request.Login,
            Senha = _authService.HashPassword(request.Senha)
        };

        await _repository.AdicionarAsync(usuario);
        return usuario.Id;
    }
}
