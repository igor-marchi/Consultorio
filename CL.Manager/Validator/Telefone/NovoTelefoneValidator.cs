using CL.Core.Shared.ModelViews.Telefone;
using FluentValidation;

namespace CL.Manager.Validator.Telefone
{
    public class NovoTelefoneValidator : AbstractValidator<NovoTelefone>
    {
        public NovoTelefoneValidator()
        {
            RuleFor(p => p.Numero)
                .Matches("[2-9][0-9]{10}")
                    .WithMessage("Telefone deve ter o formato [2-9][0-9]{10}");
        }
    }
}