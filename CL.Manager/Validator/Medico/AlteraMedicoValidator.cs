using CL.Core.Shared.ModelViews.Medico;
using CL.Manager.Interfaces.Repository;
using FluentValidation;

namespace CL.Manager.Validator.Medico
{
    public class AlteraMedicoValidator : AbstractValidator<AlteraMedico>
    {
        public AlteraMedicoValidator(IEspecialidadeRepository especialidadeRepository)
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            Include(new NovoMedicoValidator(especialidadeRepository));
        }
    }
}