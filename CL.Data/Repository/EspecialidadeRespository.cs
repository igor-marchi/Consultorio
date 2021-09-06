using CL.Data.Context;
using CL.Manager.Interfaces.Repository;
using System.Threading.Tasks;

namespace CL.Data.Repository
{
    public class EspecialidadeRespository : IEspecialidadeRepository
    {
        private readonly ClContext context;

        public EspecialidadeRespository(ClContext context)
        {
            this.context = context;
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await context.Especialidade.FindAsync(id) != null;
        }
    }
}