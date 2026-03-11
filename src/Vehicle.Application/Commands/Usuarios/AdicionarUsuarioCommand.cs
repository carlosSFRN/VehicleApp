using MediatR;

namespace Vehicle.Application.Commands.Usuarios;

public record AdicionarUsuarioCommand(string Nome, string Login, string Senha) : IRequest<int>;
