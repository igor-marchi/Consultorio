using CL.Core.Shared.ModelViews.Cliente;
using CL.Manager.Validator.Endereco;
using FluentValidation;
using System;

namespace CL.Manager.Validator.Cliente
{
    public class NovoClienteValidator : AbstractValidator<NovoCliente>
    {
        public NovoClienteValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(150);

            RuleFor(x => x.DataNascimento)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now)
                .GreaterThan(DateTime.Now.AddYears(-130));

            RuleFor(x => x.Documento)
                .NotNull()
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(14);

            RuleFor(x => x.Telefones)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Genero)
                .NotNull();

            RuleFor(x => x.Endereco).SetValidator(new NovoEnderecoValidator());
        }
    }
}