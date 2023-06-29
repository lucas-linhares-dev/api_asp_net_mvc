using InfoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoWebApi.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options) : base(options) {
            
        }

        public DbSet<Usuario> Usuarios { get; set; } 
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
