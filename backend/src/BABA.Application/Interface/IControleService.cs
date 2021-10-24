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
        Task<Controle> AddControle(Controle model);
        Task<Controle> UpdateControle(int controleId, Controle model);
        Task<bool> DeleteControle(int controleId);

        Task<Controle[]> GetAllControleByAtletaAsync(string condutor, bool includeAtleta = false);
        Task<Controle[]> GetAllControleAsync(bool includeAtleta = false);
        Task<Controle> GetControleByIdAsync(int controleId, bool includeAtleta = false);
    }
}
