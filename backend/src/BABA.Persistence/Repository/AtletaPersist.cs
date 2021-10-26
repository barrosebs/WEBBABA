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
    public class AtletaPersist : IAtletaPersist
    {
        private readonly DBBabaContext _babaContext;

        public AtletaPersist(DBBabaContext babaContext)
        {
            _babaContext = babaContext;
        }

        public async Task<Atleta[]> GetAllAtletaAsync(bool includeMensaliade = false)
        {
            IQueryable<Atleta> query = _babaContext.Atletas;

            if (includeMensaliade)
            {
                query = query
                .Include(c => c.Mensalidades)
                .ThenInclude(p => p.MensalidadeId);
            }
            query = query.AsNoTracking().OrderBy(e => e.AtletaId);
            return await query.ToArrayAsync();
        }

        public async Task<Atleta[]> GetAllAtletaByMensalidadeAsync(string nome, bool includeAtleta = false)
        {
            IQueryable<Atleta> query = _babaContext.Atletas;

            if (includeAtleta)
            {
               //implements
            }
            query = query.AsNoTracking().OrderBy(e => e.AtletaId).Where(c => c.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Atleta> GetAtletaByIdAsync(int atletaId, bool includeAtleta = false)
        {
            IQueryable<Atleta> query = _babaContext.Atletas;

            if (includeAtleta)
            {
                //implemments
            }
            query = query.AsNoTracking().OrderBy(e => e.AtletaId)
            .Where(e => e.AtletaId == atletaId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
