using BABA.Domain.Models;
using BABA.Persistence.Context;
using BABA.Persistence.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BABA.Persistence.Repository
{
    class UsuarioPersist : IUsuarioPersist
    {
        private readonly DBBabaContext _babaContext;

        public UsuarioPersist(DBBabaContext babaContext)
        {
            _babaContext = babaContext;
        }

        public async Task<Usuario[]> GetAllUsuarioAsync()
        {
            IQueryable<Usuario> query = _babaContext.Usuarios;

            query = query.OrderBy(u => u.Nome);
            return await query.ToArrayAsync();
        }

        public async Task<Usuario[]> GetAllUsuarioByControleAsync(string nome, bool includeControle = false)
        {
            IQueryable<Usuario> query = _babaContext.Usuarios;

            if (includeControle)
            {
                //implementar caso inclua condutores para um usuario específico 
            }
            query = query.OrderBy(e => e.UsuarioId).Where(c => c.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includeControle = false)
        {
            IQueryable<Usuario> query = _babaContext.Usuarios;

            if (includeControle)
            {
                //implementar caso inclua condutores para um usuario específico 

            }
            query = query.OrderBy(e => e.UsuarioId)
            .Where(e => e.UsuarioId == usuarioId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
