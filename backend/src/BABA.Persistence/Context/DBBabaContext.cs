using BABA.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BABA.Persistence.Context
{
    public class DBBabaContext : DbContext
    {
        public DBBabaContext(DbContextOptions<DBBabaContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Controle> Controles { get; set; }
        public DbSet<Mensalidade> Mensalidades { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>().Property(u => u.Nome).IsRequired();
        }
        /// <summary>
        /// Método subscrito para quando salvar dataCadastro pegar o a data e hora atual do sistema. Caso seja alteração não faz nada!
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry =>
                                                         entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}