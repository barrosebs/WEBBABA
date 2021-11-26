using BABA.Application.Dto;
using BABA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Application.Interface
{
    public interface IControleService
    {
        Task<ControleDto> AddControle(ControleDto model);
        Task<ControleDto> UpdateControle(int controleId, ControleDto model);
        Task<bool> DeleteControle(int controleId);

        Task<ControleDto[]> GetAllControleByAtletaAsync(string condutor, bool includeAtleta = false);
        Task<ControleDto[]> GetAllControleAsync(bool includeAtleta = false);
        Task<ControleDto> GetControleByIdAsync(int controleId, bool includeAtleta = false);
    }
}
