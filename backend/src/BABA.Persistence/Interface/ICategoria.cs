using BABA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Persistence.Interface
{
    public interface ICategoria
    {
        Task<Categoria[]> GetAllCategoriaByAtletaAsync(string nome, bool includeAtleta= false);
        Task<Categoria[]> GetAllCategoriaAsync();
        Task<Categoria> GetCategoriaByIdAsync(int categoriaId, bool includeAtleta = false);
    }
}
