using BABA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Application.Interface
{
    public interface IAtletaService
    {
        Task<Atleta> AddAtleta(Atleta model);
        Task<Atleta> UpdateAtleta(int atletaId, Atleta model);
        Task<bool> DeleteAtleta(int atletaId);

        Task<Atleta[]> GetAllAtletaByAtletaAsync(string condutor, bool includeMensalidade = false);
        Task<Atleta[]> GetAllAtletaAsync(bool includeAtleta = false);
        Task<Atleta> GetAtletaByIdAsync(int atletaId, bool includeMensalidade = false);
    }
}
