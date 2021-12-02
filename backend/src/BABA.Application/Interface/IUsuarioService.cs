using BABA.Application.Dto;
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
        Task<UsuarioDto> AddUsuario(UsuarioDto model);
        Task<UsuarioDto> UpdateUsuario(int usuarioId, UsuarioDto model);
        Task<bool> DeleteUsuario(int usuarioId);

        Task<UsuarioDto[]> GetAllUsuarioByUsuarioAsync(string condutor, bool includeControle = false);
        Task<UsuarioDto[]> GetAllUsuarioAsync(bool includeUsuario = false);
        Task<UsuarioDto> GetUsuarioByIdAsync(int usuarioId, bool includeControle = false);
    }
}
