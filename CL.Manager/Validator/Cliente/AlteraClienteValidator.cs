using CL.Core.Shared.ModelViews.Cliente;
using FluentValidation;

namespace CL.Manager.Validator.Cliente
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