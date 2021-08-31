using CL.Core.Shared.ModelViews;
using FluentValidation;
using System;

namespace CL.Manager.Validator
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
                .NotNull()
                .NotEmpty()
                .Must(ValidaGenero)
                    .WithMessage("Genero precisa ser M ou F");

            RuleFor(x => x.Endereco).SetValidator(new NovoEnderecoValidator());
        }

        private bool ValidaGenero(char sexo)
        {
            var sexoUpper = Char.ToUpper(sexo);
            return sexoUpper == 'M' || sexoUpper == 'F';
        }
    }
}