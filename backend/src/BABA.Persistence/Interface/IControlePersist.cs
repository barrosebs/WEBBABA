using BABA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Persistence.Interface
{
    public interface IControlePersist
    {
        Task<Controle[]> GetAllControleByAtletaAsync(string nome, bool includeAtleta = false);
        Task<Controle[]> GetAllControleAsync(bool includeAtleta = false);
        Task<Controle> GetControleByIdAsync(int controleId, bool includeAtleta = false);
    }
}
