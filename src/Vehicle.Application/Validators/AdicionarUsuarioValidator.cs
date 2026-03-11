using FluentValidation;
using Vehicle.Application.Commands.Usuarios;

namespace Vehicle.Application.Validators;

public class AdicionarUsuarioValidator : AbstractValidator<AdicionarUsuarioCommand>
{
    public AdicionarUsuarioValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Login).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Senha).NotEmpty().MinimumLength(6);
    }
}
