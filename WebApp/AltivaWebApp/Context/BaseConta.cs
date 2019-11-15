﻿
namespace AltivaWebApp.Context
{
    using AltivaWebApp.DomainsConta;
    using Microsoft.EntityFrameworkCore;
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
        public DbSet<CatalogoContable> CatalogoContable { get; set; }
        public DbSet<Asiento> Asiento { get; set; }
        public DbSet<AsientoDetalle> AsientoDetalle { get; set; }
        public DbSet<Moneda> Moneda { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TiposDocumentosConta> TiposDoc { get; set; }
        public DbSet<ResultadoPeriodo> ResultadosPeriodo { get; set; }
        public DbSet<AsientosAnalitico> AsientosAnalitico { get; set; }
    }
}
