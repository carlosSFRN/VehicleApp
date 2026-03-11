using FluentValidation;
using Vehicle.Application.Commands.Veiculos;

namespace Vehicle.Application.Validators;

public class AdicionarVeiculoValidator : AbstractValidator<AdicionarVeiculoCommand>
{
    public AdicionarVeiculoValidator()
    {
        RuleFor(x => x.Descricao).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Marca).IsInEnum();
        RuleFor(x => x.Modelo).NotEmpty().MaximumLength(30);
    }
}
