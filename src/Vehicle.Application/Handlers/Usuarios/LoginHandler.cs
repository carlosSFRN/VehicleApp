using MediatR;
using Vehicle.Application.Commands.Usuarios;
using Vehicle.Application.Services;
using Vehicle.Domain.Interfaces;

namespace Vehicle.Application.Handlers.Usuarios;

public class LoginHandler : IRequestHandler<LoginCommand, string?>
{
    private readonly IUsuarioRepository _repository;
    private readonly IAuthService _authService;

    public LoginHandler(IUsuarioRepository repository, IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    public async Task<string?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _repository.ObterPorLoginAsync(request.Login);
        if (usuario == null || !_authService.VerifyPassword(request.Senha, usuario.Senha))
            return null;

        return _authService.GenerateToken(usuario.Id, usuario.Login);
    }
}
