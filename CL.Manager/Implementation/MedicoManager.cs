using CL.Core.Shared.ModelViews.Medico;
using CL.Manager.Interfaces.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Implementation
{
    public class MedicoManager : IMedicoManager
    {
        public Task DeleteMedicoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicoView> GetMedicoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicoView> GetMedicosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MedicoView> InsertMedicoAsync(NovoMedico medico)
        {
            throw new NotImplementedException();
        }

        public Task<MedicoView> UpdateMedicoAsync(AlteraMedico medico)
        {
            throw new NotImplementedException();
        }
    }
}