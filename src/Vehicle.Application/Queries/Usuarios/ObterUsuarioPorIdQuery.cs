using MediatR;
using Vehicle.Domain.Entities;

namespace Vehicle.Application.Queries.Usuarios;

public record ObterUsuarioPorIdQuery(int Id) : IRequest<Usuario?>;
