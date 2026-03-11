using MediatR;

namespace Vehicle.Application.Commands.Usuarios;

public record LoginCommand(string Login, string Senha) : IRequest<string?>;
