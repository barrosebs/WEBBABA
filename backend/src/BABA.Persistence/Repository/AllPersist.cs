using BABA.Persistence.Context;
using BABA.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Persistence.Repository
{
    public class AllPersist : IAllPerssit
    {
        private readonly DBBabaContext _context;

        public AllPersist(DBBabaContext context){
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

    }
}
