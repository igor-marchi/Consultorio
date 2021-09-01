using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Data.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ClContext context;

        public MedicoRepository(ClContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await context.Medico
                .Include(p => p.Especialidades)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medico> GetMedicoAsync(long id)
        {
            return await context.Medico
                .Include(p => p.Especialidades)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            await InsertMedicoEspeciliade(medico);
            await context.Medico.AddAsync(medico);

            await context.SaveChangesAsync();

            return medico;
        }

        private async Task InsertMedicoEspeciliade(Medico medico)
        {
            var especialidadesConsultadas = new List<Especialidade>();
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await context.Especialidade.FirstAsync(x => x.Id == especialidade.Id);
                especialidadesConsultadas.Add(especialidadeConsultada);
            }

            medico.Especialidades = especialidadesConsultadas;
        }

        public async Task<Medico> UpdateMedicoAsync(Medico medico)
        {
            var medicoConsultado = await context.Medico
                                            .Include(x => x.Especialidades)
                                            .SingleOrDefaultAsync(x => x.Id == medico.Id);

            if (medicoConsultado == null)
                return null;

            await UpdateMedicoEspecialidades(medico, medicoConsultado);
            await context.SaveChangesAsync();

            return medicoConsultado;
        }

        private async Task UpdateMedicoEspecialidades(Medico medico, Medico medicoConsultado)
        {
            var especialidadesConsultadas = new List<Especialidade>();
            foreach (var especialidade in medico.Especialidades)
            {
                var especoalidadeConsultada = await context.Especialidade.FindAsync(especialidade.Id);
                especialidadesConsultadas.Add(especoalidadeConsultada);
            }

            medicoConsultado.Especialidades = especialidadesConsultadas;
        }

        public async Task DeleteMedicoAsync(long id)
        {
            var medicoConsultado = await GetMedicoAsync(id);
            context.Medico.Remove(medicoConsultado);
            await context.SaveChangesAsync();
        }
    }
}