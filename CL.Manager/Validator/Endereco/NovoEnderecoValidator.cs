using CL.Core.Shared.ModelViews.Endereco;
using FluentValidation;

namespace CL.Manager.Validator.Endereco
{
    public class NovoEnderecoValidator : AbstractValidator<NovoEndereco>
    {
        public NovoEnderecoValidator()
        {
            RuleFor(p => p.Cidade)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
        }
    }
}