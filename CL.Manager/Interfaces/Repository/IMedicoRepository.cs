using CL.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces.Repository
{
    public interface IMedicoRepository
    {
        Task DeleteMedicoAsync(long id);

        Task<Medico> GetMedicoAsync(long id);

        Task<IEnumerable<Medico>> GetMedicosAsync();

        Task<Medico> InsertMedicoAsync(Medico medico);

        Task<Medico> UpdateMedicoAsync(Medico medico);
    }
}