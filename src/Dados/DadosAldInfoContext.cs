using Microsoft.EntityFrameworkCore;
using Entidades;

namespace Dados
{
    public class DadosAldInfoContext : DbContext
    {
        public static string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<ALD_ETL_Database> ALD_ETL_Database { get; set; }
    }
}
