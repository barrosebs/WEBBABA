using BABA.Domain.Models;
using System.Threading.Tasks;

namespace BABA.Persistence.Interface
{
    public interface IUsuario
    {
        Task<Usuario[]> GetAllUsuarioByControleAsync(string nome, bool includeControle = false);
        Task<Usuario[]> GetAllUsuarioAsync();
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includeControle = false);
    }
}
