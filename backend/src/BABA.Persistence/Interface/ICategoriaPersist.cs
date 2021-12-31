using BABA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Persistence.Interface
{
    public interface ICategoriaPersist
    {
        Task<Categoria[]> GetAllCategoriaAsync();
        Task<Categoria> GetCategoriaByIdAsync(int categoriaId);
    }
}
