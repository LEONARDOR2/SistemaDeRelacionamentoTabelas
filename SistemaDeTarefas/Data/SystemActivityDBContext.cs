using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SystemActivityDBContext : DbContext
    {

        public SystemActivityDBContext(DbContextOptions<SystemActivityDBContext> options) : base(options)
        {
            
        }

          public DbSet<UserModel> Users { get; set; }
          public DbSet<ActivityModel> Activity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurar o uso do banco de dados em memória
            optionsBuilder.UseInMemoryDatabase("CarrosDB");
        }
    }
}
