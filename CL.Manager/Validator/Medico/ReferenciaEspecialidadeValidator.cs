using CL.Core.Shared.ModelViews.Especialidade;
using CL.Manager.Interfaces.Repository;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace CL.Manager.Validator.Medico
{
    public class ReferenciaEspecialidadeValidator : AbstractValidator<ReferenciaEspecialidade>
    {
        private readonly IEspecialidadeRepository especialidadeRepository;

        public ReferenciaEspecialidadeValidator(IEspecialidadeRepository especialidadeRepository)
        {
            this.especialidadeRepository = especialidadeRepository;

            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .MustAsync(async (id, cancelar) => await ExisteNaBase(id))
                    .WithMessage("Especialidade não cadastrada");
        }

        private async Task<bool> ExisteNaBase(int id)
        {
            return await especialidadeRepository.ExisteAsync(id);
        }
    }
}