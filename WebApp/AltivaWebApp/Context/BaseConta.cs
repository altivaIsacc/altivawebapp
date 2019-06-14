
namespace AltivaWebApp.Context 
{
    using Microsoft.EntityFrameworkCore;using AltivaWebApp.DomainsConta;
    public class BaseConta : DbContext  
    {
        public BaseConta(DbContextOptions<BaseConta> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Helpers.StringProvider.StringEmpresas);
            }
        }
        public DbSet<PeriodoFiscal> PeriodoFiscal { get; set; }
        public DbSet<PeriodoTrabajo> PeriodoTrabajo { get; set; }
        public DbSet<ConfiguracionContable> ConfiguracionContable { get; set; }

    }
}
