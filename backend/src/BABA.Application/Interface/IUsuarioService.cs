using BABA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Application.Interface
{
    public interface IUsuarioService
    {
        Task<Usuario> AddUsuario(Usuario model);
        Task<Usuario> UpdateUsuario(int usuarioId, Usuario model);
        Task<bool> DeleteUsuario(int usuarioId);

        Task<Usuario[]> GetAllUsuarioByUsuarioAsync(string condutor, bool includeControle = false);
        Task<Usuario[]> GetAllUsuarioAsync(bool includeUsuario = false);
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includeControle = false);
    }
}
