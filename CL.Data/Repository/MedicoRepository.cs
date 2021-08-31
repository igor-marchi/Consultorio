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

        public async Task<Medico> InsertMedicoAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Medico> UpdateMedicoAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMedicoAsync(long id)
        {
            var medicoConsultado = await GetMedicoAsync(id);
            context.Medico.Remove(medicoConsultado);
            await context.SaveChangesAsync();
        }
    }
}