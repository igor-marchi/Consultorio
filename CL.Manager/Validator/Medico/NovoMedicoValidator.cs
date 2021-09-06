using CL.Core.Shared.ModelViews.Medico;
using CL.Manager.Interfaces.Repository;
using FluentValidation;

namespace CL.Manager.Validator.Medico
{
    public class NovoMedicoValidator : AbstractValidator<NovoMedico>
    {
        public NovoMedicoValidator(IEspecialidadeRepository especialidadeRepository)
        {
            RuleFor(p => p.Nome)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(p => p.CRM)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleForEach(p => p.Especialidades)
                .SetValidator(new ReferenciaEspecialidadeValidator(especialidadeRepository));
        }
    }
}