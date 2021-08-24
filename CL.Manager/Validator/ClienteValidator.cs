using CL.Core.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Validator
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
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

            RuleFor(x => x.Telefone)
                .NotNull()
                .NotEmpty()
                .Matches("[2-9][0-9]{10}")
                    .WithMessage("Telefone deve ter o formato [2-9][0-9]{10}");

            RuleFor(x => x.Genero)
                .NotNull()
                .NotEmpty()
                .Must(ValidaGenero)
                    .WithMessage("Genero precisa ser M ou F");
        }

        private bool ValidaGenero(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }
    }
}