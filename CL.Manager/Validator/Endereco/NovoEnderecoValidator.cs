using CL.Core.Shared.ModelViews.Endereco;
using FluentValidation;

namespace CL.Manager.Validator.Endereco
{
    public class NovoEnderecoValidator : AbstractValidator<NovoEndereco>
    {
        public NovoEnderecoValidator()
        {
            RuleFor(p => p.CEP)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Cidade)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);

            RuleFor(p => p.Estado)
                .NotNull();

            RuleFor(p => p.Logradouro)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);

            RuleFor(p => p.Complemento)
               .NotEmpty()
               .NotNull()
               .MaximumLength(200);

            RuleFor(p => p.Numero)
                .NotEmpty()
                .NotNull()
                .MaximumLength(10);
        }
    }
}