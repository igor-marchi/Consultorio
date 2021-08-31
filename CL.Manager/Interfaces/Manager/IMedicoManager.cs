using CL.Core.Shared.ModelViews.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces.Manager
{
    public interface IMedicoManager
    {
        Task<MedicoView> GetMedicosAsync();

        Task<MedicoView> GetMedicoAsync(int id);

        Task<MedicoView> InsertMedicoAsync(NovoMedico medico);

        Task<MedicoView> UpdateMedicoAsync(AlteraMedico medico);

        Task DeleteMedicoAsync(int id);
    }
}