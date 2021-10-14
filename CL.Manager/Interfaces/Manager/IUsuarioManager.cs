using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces.Manager
{
    public interface IUsuarioManager
    {
        Task<List<UsuarioView>> GetAllAsync();

        Task<UsuarioView> GetOneAsync(string login);

        Task<UsuarioView> InsertAsync(NovoUsuario novoUsuario);

        Task<UsuarioView> UpdateUsuarioAsync(Usuario usuario);

        Task<UsuarioLogado> ValidarUsuarioEGerarTokenAsync(Usuario usuario);
    }
}