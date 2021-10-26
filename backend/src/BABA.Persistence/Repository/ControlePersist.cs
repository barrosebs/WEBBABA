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
    public class ControlePersist : IControlePersist
    {
        private readonly DBBabaContext _babaContext;

        public ControlePersist(DBBabaContext babaContext)
        {
            _babaContext = babaContext;
        }

        public Task<Controle[]> GetAllControleAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Controle[]> GetAllControleByCondutorAsync(string nome, bool includeAtleta = false)
        {
            IQueryable<Controle> query = _babaContext.Controles;

            if (includeAtleta)
            {
               //implements
            }
            query = query.AsNoTracking().OrderBy(e => e.CategoriaId).Where(c => c.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Controle> GetControleByIdAsync(int controleId, bool includeAtleta = false)
        {
            IQueryable<Controle> query = _babaContext.Controles;

            if (includeAtleta)
            {
                //implemments
            }
            query = query.AsNoTracking().OrderBy(e => e.CategoriaId)
            .Where(e => e.CategoriaId == controleId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
