using BABA.Application.Dto;
using BABA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Application.Interface
{
    public interface ICategoriaService
    {
        Task<CategoriaDto> AddCategoria(CategoriaDto model);
        Task<CategoriaDto> UpdateCategoria(int CategoriaId, CategoriaDto model);
        Task<bool> DeleteCategoria(int CategoriaId);
        Task<CategoriaDto[]> GetAllByAsync();
        Task<CategoriaDto> GetCategoriaByIdAsync(int CategoriaId);
    }
}
