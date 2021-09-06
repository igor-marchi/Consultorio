using System.Threading.Tasks;

namespace CL.Manager.Interfaces.Repository
{
    public interface IEspecialidadeRepository
    {
        Task<bool> ExisteAsync(int id);
    }
}