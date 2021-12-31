using BABA.Domain.Models;
using BABA.Persistence.Context;
using BABA.Persistence.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Persistence.Repository
{
    public class CategoriaPersist : ICategoriaPersist
    {
        private readonly DBBabaContext _babaContext;

        public CategoriaPersist(DBBabaContext babaContext)
        {
            _babaContext = babaContext;
        }

        public async Task<Categoria[]> GetAllCategoriaAsync()
        {
            IQueryable<Categoria> query = _babaContext.Categorias;

            query = query.AsNoTracking().OrderBy(e => e.CategoriaId);
            return await query.ToArrayAsync();
        }


        public async Task<Categoria> GetCategoriaByIdAsync(int categoriaId)
        {
            IQueryable<Categoria> query = _babaContext.Categorias;

            query = query.AsNoTracking().OrderBy(e => e.CategoriaId)
            .Where(e => e.CategoriaId == categoriaId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
