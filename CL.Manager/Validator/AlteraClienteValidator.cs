using CL.Core.Shared.ModelViews;
using FluentValidation;

namespace CL.Manager.Validator
{
    public class AlteraClienteValidator : AbstractValidator<AlteraCliente>
    {
        public AlteraClienteValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            Include(new NovoClienteValidator());
        }
    }
}