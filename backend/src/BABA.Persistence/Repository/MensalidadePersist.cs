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
    public class MensalidadePersist : IMensalidadePersist
    {
        private readonly DBBabaContext _babaContext;

        public MensalidadePersist(DBBabaContext babaContext)
        {
            _babaContext = babaContext;
        }

        public async Task<Mensalidade[]> GetAllMensalidadeAsync(bool includeAtleta = false)
        {
            IQueryable<Mensalidade> query = _babaContext.Mensalidades;

            if (includeAtleta)
            {
                query = query
                .Include(c => c.Atleta)
                .ThenInclude(p => p.AtletaId);
            }
            query = query.AsNoTracking().OrderBy(e => e.MensalidadeId);
            return await query.ToArrayAsync();
        }

        public async Task<Mensalidade[]> GetAllMensalidadeByAtletaAsync(string vencimento, bool includeAtleta = false)
        {
            IQueryable<Mensalidade> query = _babaContext.Mensalidades;

            if (includeAtleta)
            {
                //implements
            }
            query = query.AsNoTracking().OrderBy(e => e.MensalidadeId);//.Where(c => c.Vencimento.Contains(vencimento.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Mensalidade> GetMensalidadeByIdAsync(int MensalidadeId, bool includeAtleta = false)
        {
            IQueryable<Mensalidade> query = _babaContext.Mensalidades;

            if (includeAtleta)
            {
                //implemments
            }
            query = query.AsNoTracking().OrderBy(e => e.MensalidadeId)
            .Where(e => e.MensalidadeId == MensalidadeId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
