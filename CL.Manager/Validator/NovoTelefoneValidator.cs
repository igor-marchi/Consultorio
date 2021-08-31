using CL.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Validator
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