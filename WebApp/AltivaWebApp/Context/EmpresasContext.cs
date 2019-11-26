using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using AltivaWebApp.Helpers;

namespace AltivaWebApp.Context
{
    public partial class EmpresasContext : DbContext
    {
        public EmpresasContext()
        {
        }

        public EmpresasContext(DbContextOptions<EmpresasContext> options)
            : base(options)
        {

        }
        public DbSet<tbPRTipoAjusteInventario> TiposAjusteInventario { get; set; }
        public DbSet<FacturaBusqueda> FacturasBusquedas { get; set; }
        public DbSet<DocContacto> DocumentosC { get; set; }
        //no autogenerado / no borrar
        public virtual DbSet<CompraAutomaticoViewModel> CompraAutomatico { get; set; }
        public virtual DbSet<ListarInventarioViewModel> ListarInventario { get; set; }
        public virtual DbSet<DocumentosContactoViewModel> DocumentosContacto { get; set; }
        public virtual DbSet<DocumentosSaldoGeneralViewModel> DocumentosSaldoGeneral { get; set; }
        public virtual DbSet<ContactoSaldoGeneralViewModel> ContactoSaldoGeneral { get; set; }


        public virtual DbSet<TbCrContactoVisita> TbCrContactoVisita { get; set; }
        public virtual DbSet<TbCrVisitaTipo> TbCrVisitaTipo { get; set; }

        public virtual DbSet<TbBaFlujo> TbBaFlujo { get; set; }
        public virtual DbSet<TbBaFlujoCategoria> TbBaFlujoCategoria { get; set; }
        public virtual DbSet<TbCeCanton> TbCeCanton { get; set; }
        public virtual DbSet<TbCeCodigosReferencia> TbCeCodigosReferencia { get; set; }
        public virtual DbSet<TbCeCofiguracion> TbCeCofiguracion { get; set; }
        public virtual DbSet<TbCeColaAprobacion> TbCeColaAprobacion { get; set; }
        public virtual DbSet<TbCeComprobantesEnviados> TbCeComprobantesEnviados { get; set; }
        public virtual DbSet<TbCeConsecutivoProvisionalHa> TbCeConsecutivoProvisionalHa { get; set; }
        public virtual DbSet<TbCeDistrito> TbCeDistrito { get; set; }
        public virtual DbSet<TbCeProvincias> TbCeProvincias { get; set; }
        public virtual DbSet<TbCeSucursal> TbCeSucursal { get; set; }
        public virtual DbSet<TbFaNota> TbFaNota { get; set; }
        public virtual DbSet<TbCeTipoIdentificacion> TbCeTipoIdentificacion { get; set; }
        public virtual DbSet<TbCeTiposDocElectronicos> TbCeTiposDocElectronicos { get; set; }
        public virtual DbSet<TbCoAsientoContable> TbCoAsientoContable { get; set; }
        public virtual DbSet<TbCoAsientoContableDetalle> TbCoAsientoContableDetalle { get; set; }
        public virtual DbSet<TbCoCentrosDeGastos> TbCoCentrosDeGastos { get; set; }
        public virtual DbSet<TbCoConfiguracion> TbCoConfiguracion { get; set; }
        public virtual DbSet<TbCoCuentaContable> TbCoCuentaContable { get; set; }
        public virtual DbSet<TbCoPeriodoFiscal> TbCoPeriodoFiscal { get; set; }
        public virtual DbSet<TbCoPeriodoTrabajo> TbCoPeriodoTrabajo { get; set; }
        public virtual DbSet<TbCoSetting> TbCoSetting { get; set; }
        public virtual DbSet<TbCoSettingTipo> TbCoSettingTipo { get; set; }
        public virtual DbSet<TbCoTipoCuenta> TbCoTipoCuenta { get; set; }
        public virtual DbSet<TbCoTiposDocumentos> TbCoTiposDocumentos { get; set; }
        public virtual DbSet<TbCoUtilidadRenta> TbCoUtilidadRenta { get; set; }
        public virtual DbSet<TbCpCategoriaGasto> TbCpCategoriaGasto { get; set; }
        public virtual DbSet<TbCpComprasDetalleServicio> TbCpComprasDetalleServicio { get; set; }
        public virtual DbSet<TbCrCamposPersonalizados> TbCrCamposPersonalizados { get; set; }
        public virtual DbSet<TbCrContacto> TbCrContacto { get; set; }
        public virtual DbSet<TbCrContactoRelacion> TbCrContactoRelacion { get; set; }
        public virtual DbSet<TbCrContactosCamposPersonalizados> TbCrContactosCamposPersonalizados { get; set; }
        public virtual DbSet<TbCrListaDesplegables> TbCrListaDesplegables { get; set; }
        public virtual DbSet<TbFaCaja> TbFaCaja { get; set; }
        public virtual DbSet<TbFaCajaAperturaDenominacion> TbFaCajaAperturaDenominacion { get; set; }
        public virtual DbSet<TbFaCajaArqueo> TbFaCajaArqueo { get; set; }
        public virtual DbSet<TbFaCajaArqueoDenominacion> TbFaCajaArqueoDenominacion { get; set; }
        public virtual DbSet<TbFaCajaArqueoOperadorTarjeta> TbFaCajaArqueoOperadorTarjeta { get; set; }
        public virtual DbSet<TbFaCajaCierre> TbFaCajaCierre { get; set; }
        public virtual DbSet<TbFaCajaMovimiento> TbFaCajaMovimiento { get; set; }
        public virtual DbSet<TbFaCajaMovimientoCheque> TbFaCajaMovimientoCheque { get; set; }
        public virtual DbSet<TbFaCajaMovimientoFlujo> TbFaCajaMovimientoFlujo { get; set; }
        public virtual DbSet<TbFaCajaMovimientoTarjeta> TbFaCajaMovimientoTarjeta { get; set; }
        public virtual DbSet<TbFaCotizacion> TbFaCotizacion { get; set; }
        public virtual DbSet<TbFaCotizacionConfig> TbFaCotizacionConfig { get; set; }
        public virtual DbSet<TbFaCotizacionDetalle> TbFaCotizacionDetalle { get; set; }
        public virtual DbSet<TbFaDenominacion> TbFaDenominacion { get; set; }
        public virtual DbSet<TbFaDescuentoProducto> TbFaDescuentoProducto { get; set; }
        public virtual DbSet<TbFaDescuentoUsuario> TbFaDescuentoUsuario { get; set; }
        public virtual DbSet<TbFaDescuentoUsuarioClave> TbFaDescuentoUsuarioClave { get; set; }
        public virtual DbSet<TbFaDescuentoUsuarioRango> TbFaDescuentoUsuarioRango { get; set; }
        public virtual DbSet<TbFaMovimiento> TbFaMovimiento { get; set; }
        public virtual DbSet<TbFaPago> TbFaPago { get; set; }
        public virtual DbSet<TbFaMovimientoDetalle> TbFaMovimientoDetalle { get; set; }
        public virtual DbSet<TbFaMovimientoJustificante> TbFaMovimientoJustificante { get; set; }
        public virtual DbSet<TbFaPromocionProducto> TbFaPromocionProducto { get; set; }
        public virtual DbSet<TbFaRebajaConfig> TbFaRebajaConfig { get; set; }
        public virtual DbSet<TbFaTipoCajaMovimiento> TbFaTipoCajaMovimiento { get; set; }
        public virtual DbSet<TbFaTipoDocumento> TbFaTipoDocumento { get; set; }
        public virtual DbSet<TbFaTipoJustificante> TbFaTipoJustificante { get; set; }
        public virtual DbSet<TbFdCondicionesDePago> TbFdCondicionesDePago { get; set; }
        public virtual DbSet<TbFdConfiguracionFiltros> TbFdConfiguracionFiltros { get; set; }
        public virtual DbSet<TbFdCuentasBancarias> TbFdCuentasBancarias { get; set; }
        public virtual DbSet<TbFdFactura> TbFdFactura { get; set; }
        public virtual DbSet<TbFdFacturaDetalle> TbFdFacturaDetalle { get; set; }
        public virtual DbSet<TbFdSubtareas> TbFdSubtareas { get; set; }
        public virtual DbSet<TbFdTarea> TbFdTarea { get; set; }
        public virtual DbSet<TbFdTareaEstado> TbFdTareaEstado { get; set; }
        public virtual DbSet<TbFdTareaTipo> TbFdTareaTipo { get; set; }
        public virtual DbSet<TbFdTipoCliente> TbFdTipoCliente { get; set; }
        public virtual DbSet<TbFdTipoProveedor> TbFdTipoProveedor { get; set; }
        public virtual DbSet<TbPrAjuste> TbPrAjuste { get; set; }
        public virtual DbSet<TbPrAjusteInventario> TbPrAjusteInventario { get; set; }
        public virtual DbSet<TbPrBodega> TbPrBodega { get; set; }
        public virtual DbSet<TbPrCompra> TbPrCompra { get; set; }
        public virtual DbSet<TbPrCompraDetalle> TbPrCompraDetalle { get; set; }
        public virtual DbSet<TbPrConversion> TbPrConversion { get; set; }
        public virtual DbSet<TbPrDepartamento> TbPrDepartamento { get; set; }
        public virtual DbSet<TbPrEquivalencia> TbPrEquivalencia { get; set; }
        public virtual DbSet<TbPrFamilia> TbPrFamilia { get; set; }
        public virtual DbSet<TbPrFamiliaVentaOnline> TbPrFamiliaVentaOnline { get; set; }
        public virtual DbSet<TbPrImagenInventario> TbPrImagenInventario { get; set; }
        public virtual DbSet<TbPrInformacionBancaria> TbPrInformacionBancaria { get; set; }
        public virtual DbSet<TbPrInventario> TbPrInventario { get; set; }
        public virtual DbSet<TbPrInventarioBodega> TbPrInventarioBodega { get; set; }
        public virtual DbSet<TbPrInventarioCaracteristica> TbPrInventarioCaracteristica { get; set; }
        public virtual DbSet<TbPrKardex> TbPrKardex { get; set; }
        public virtual DbSet<TbPrOrden> TbPrOrden { get; set; }
        public virtual DbSet<TbPrOrdenDetalle> TbPrOrdenDetalle { get; set; }
        public virtual DbSet<TbPrPrecioCatalogo> TbPrPrecioCatalogo { get; set; }
        public virtual DbSet<TbPrPrecios> TbPrPrecios { get; set; }
        public virtual DbSet<TbPrPreciosInventarios> TbPrPreciosInventarios { get; set; }
        public virtual DbSet<TbPrPreciosInventariosAutomaticos> TbPrPreciosInventariosAutomaticos { get; set; }
        public virtual DbSet<TbPrPreciosInventariosAutomaticosDetalle> TbPrPreciosInventariosAutomaticosDetalle { get; set; }
        public virtual DbSet<TbPrPreciosInventariosDetalle> TbPrPreciosInventariosDetalle { get; set; }
        public virtual DbSet<TbPrRequisicion> TbPrRequisicion { get; set; }
        public virtual DbSet<TbPrRequisicionDetalle> TbPrRequisicionDetalle { get; set; }
        public virtual DbSet<TbPrTipoProveedor> TbPrTipoProveedor { get; set; }
        public virtual DbSet<TbPrToma> TbPrToma { get; set; }
        public virtual DbSet<TbPrTomaDetalle> TbPrTomaDetalle { get; set; }
        public virtual DbSet<TbPrTraslado> TbPrTraslado { get; set; }
        public virtual DbSet<TbPrTrasladoInventario> TbPrTrasladoInventario { get; set; }
        public virtual DbSet<TbPrUnidadMedida> TbPrUnidadMedida { get; set; }
        public virtual DbSet<TbSeConfiguracion> TbSeConfiguracion { get; set; }
        public virtual DbSet<TbSePuntoVenta> TbSePuntoVenta { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringProvider.StringEmpresas);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");


            modelBuilder.Entity<TbCrContactoVisita>(entity =>
            {
                entity.HasKey(e => e.IdContactoVisita);

                entity.ToTable("TB_CR_ContactoVisita");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdVisitaTipoNavigation)
                    .WithMany(p => p.TbCrContactoVisita)
                    .HasForeignKey(d => d.IdVisitaTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_CR_ContactoVisita_TB_CR_VisitaTipo");
            });

            modelBuilder.Entity<TbCrVisitaTipo>(entity =>
            {
                entity.HasKey(e => e.IdVisitaTipo);

                entity.ToTable("TB_CR_VisitaTipo");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbPrTraslado>(entity =>
            {
                entity.HasKey(e => e.IdTraslado);

                entity.ToTable("tb_PR_Traslado");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdBodegaDestinoNavigation)
                    .WithMany(p => p.TbPrTrasladoIdBodegaDestinoNavigation)
                    .HasForeignKey(d => d.IdBodegaDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Traslado_tb_PR_Bodega1");

                entity.HasOne(d => d.IdBodegaOrigenNavigation)
                    .WithMany(p => p.TbPrTrasladoIdBodegaOrigenNavigation)
                    .HasForeignKey(d => d.IdBodegaOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Traslado_tb_PR_Bodega");
            });

            modelBuilder.Entity<TbPrTrasladoInventario>(entity =>
            {
                entity.ToTable("tb_PR_TrasladoInventario");

                entity.Property(e => e.CodigoArticulo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrTrasladoInventario)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_TrasladoInventario_tb_PR_Inventario");

                entity.HasOne(d => d.IdTrasladoNavigation)
                    .WithMany(p => p.TbPrTrasladoInventario)
                    .HasForeignKey(d => d.IdTraslado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_TrasladoInventario_tb_PR_Traslado");
            });

            modelBuilder.Entity<DocumentosSaldoGeneralViewModel>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento);
                entity.Property(e => e.SaldoBase).HasColumnName("SaldoBase");
                entity.Property(e => e.SaldoDolar).HasColumnName("SaldoDolar");
                entity.Property(e => e.SaldoEuro).HasColumnName("SaldoEuro");
                entity.Property(e => e.IdContacto).HasColumnName("IdContacto");
                entity.Property(e => e.IdDocumento).HasColumnName("IdDocumento");
                entity.Property(e => e.FechaCreacion).HasColumnName("FechaCreacion");              
            });

            modelBuilder.Entity<ContactoSaldoGeneralViewModel>(entity =>
            {
                entity.HasKey(e => e.IdContacto);
                entity.Property(e => e.Nombre).HasColumnName("Nombre");
                entity.Property(e => e.Apellidos).HasColumnName("Apellidos");
                entity.Property(e => e.NombreComercial).HasColumnName("NombreComercial");
                entity.Property(e => e.Cedula).HasColumnName("Cedula");
                entity.Property(e => e.PlazoCredito).HasColumnName("PlazoCredito");
                entity.Property(e => e.MontoMaximo).HasColumnName("MontoMaximo");
            });

            modelBuilder.Entity<ListarInventarioViewModel>(entity =>
                {
                    entity.HasKey(e => e.IdInventario);

                    entity.ToTable("vs_Pr_ListarIventario");

                    entity.Property(e => e.Codigo).HasColumnName("Codigo");
                    entity.Property(e => e.Descripcion).HasColumnName("Descripcion");
                    entity.Property(e => e.CantidadUnidad).HasColumnName("CantidadUnidad");
                    entity.Property(e => e.ExistenciaGeneral).HasColumnName("ExistenciaGeneral");
                    entity.Property(e => e.Inactiva).HasColumnName("Inactiva");
                    entity.Property(e => e.IdSubFamilia).HasColumnName("IdSubFamilia");
                    entity.Property(e => e.Abreviatura).HasColumnName("Abreviatura");
                    entity.Property(e => e.PrecioVentaFinal).HasColumnName("PrecioVentaFinal");
                    entity.Property(e => e.Simbolo).HasColumnName("Simbolo");
                    entity.Property(e => e.ExistenciaMinima).HasColumnName("ExistenciaMinima");
                    entity.Property(e => e.ExistenciaMaxima).HasColumnName("ExistenciaMaxima");
                    entity.Property(e => e.ExistenciaMedia).HasColumnName("ExistenciaMedia");
                    entity.Property(e => e.IdBodega).HasColumnName("IdBodega");
                    entity.Property(e => e.IdFamilia).HasColumnName("IdFamilia");

                });


            modelBuilder.Entity<CompraAutomaticoViewModel>(entity =>
            {
                entity.HasKey(e => e.IdInventario);
                entity.Property(e => e.Codigo).HasColumnType("varchar(60)");
                entity.Property(e => e.Descripcion).HasColumnType("varchar(150)");
                entity.Property(e => e.etotal).HasColumnType("float");
                entity.Property(e => e.ExistenciaGeneral).HasColumnType("float");
                entity.Property(e => e.emed).HasColumnType("float");
                entity.Property(e => e.emin).HasColumnType("float");
                entity.Property(e => e.emax).HasColumnType("float");
            });
            modelBuilder.Entity<DocumentosContactoViewModel>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento);

                entity.ToTable("vs_FA_DocumentosContacto");

                entity.Property(e => e.Nombre).HasMaxLength(150);
                entity.Property(e => e.IdContacto).HasColumnName("IdContacto");
                entity.Property(e => e.IdTipoDocumento).HasColumnName("IdTipoDocumento");
                entity.Property(e => e.IdUsuario).HasColumnName("IdUsuario");
                entity.Property(e => e.Cxp).HasColumnName("Cxp");
                entity.Property(e => e.Cxc).HasColumnName("Cxc");
                entity.Property(e => e.IdMoneda).HasColumnName("IdMoneda");
                //entity.Property(e => e.MontoBase).HasColumnName("MontoBase");
                //entity.Property(e => e.MontoDolar).HasColumnName("MontoDolar");
                //entity.Property(e => e.MontoEuro).HasColumnName("MontoEuro");
                //entity.Property(e => e.DisponibleDolar).HasColumnName("DisponibleDolar");
                //entity.Property(e => e.DisponibleBase).HasColumnName("DisponibleBase");
                //entity.Property(e => e.DisponibleEuro).HasColumnName("DisponibleEuro");
                //entity.Property(e => e.AplicadoBase).HasColumnName("AplicadoBase");
                //entity.Property(e => e.AplicadoDolar).HasColumnName("AplicadoDolar");
                //entity.Property(e => e.AplicadoEuro).HasColumnName("AplicadoEuro");
                //entity.Property(e => e.SaldoBase).HasColumnName("SaldoBase");
                //entity.Property(e => e.SaldoDolar).HasColumnName("SaldoDolar");
                //entity.Property(e => e.SaldoEuro).HasColumnName("SaldoEuro");
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
                entity.Property(e => e.EsDebito).HasColumnName("EsDebito");
                entity.Property(e => e.Concecutivo).HasColumnName("Concecutivo");
                entity.Property(e => e.FechaDocumento).HasColumnType("datetime");
                entity.Property(e => e.IdVendedor).HasColumnName("IdVendedor");
                entity.Property(e => e.IdPuntoVenta).HasColumnName("IdPuntoVenta");
                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");
                entity.Property(e => e.Estado).HasColumnName("Estado");

            });

            modelBuilder.Entity<TbBaFlujo>(entity =>
            {
                entity.HasKey(e => e.IdFlujo);

                entity.ToTable("tb_BA_Flujo");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaUltimaMod)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdTipo).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdCategoriaFlujoNavigation)
                    .WithMany(p => p.TbBaFlujo)
                    .HasForeignKey(d => d.IdCategoriaFlujo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_BA_Flujo_tb_BA_FlujoCategoria");
            });

            modelBuilder.Entity<TbBaFlujoCategoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaFlujo);

                entity.ToTable("tb_BA_FlujoCategoria");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdTipoFlujo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbCeCanton>(entity =>
            {
                entity.HasKey(e => new { e.IdProvincia, e.IdCanton });

                entity.ToTable("TB_CE_Canton");

                entity.Property(e => e.IdProvincia).HasColumnName("id_Provincia");

                entity.Property(e => e.IdCanton).HasColumnName("id_Canton");

                entity.Property(e => e.DescCanton)
                    .IsRequired()
                    .HasColumnName("Desc_Canton")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCeCodigosReferencia>(entity =>
            {
                entity.HasKey(e => e.IdCodigoReferencia);

                entity.ToTable("TB_CE_Codigos_Referencia");

                entity.Property(e => e.IdCodigoReferencia)
                    .HasColumnName("id_codigo_Referencia")
                    .HasMaxLength(2)
                    .ValueGeneratedNever();

                entity.Property(e => e.DescCodigoReferencia)
                    .IsRequired()
                    .HasColumnName("Desc_Codigo_Referencia")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCeCofiguracion>(entity =>
            {
                entity.ToTable("TB_CE_Cofiguracion");

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasColumnName("Client_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientSecret)
                    .HasColumnName("Client_Secret")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConsecutivoCargaXml)
                    .IsRequired()
                    .HasColumnName("Consecutivo_CargaXML")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConsecutivoHaFe)
                    .IsRequired()
                    .HasColumnName("consecutivo_HA_FE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConsecutivoHaNce)
                    .IsRequired()
                    .HasColumnName("Consecutivo_HA_NCE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConsecutivoHaNde)
                    .IsRequired()
                    .HasColumnName("Consecutivo_HA_NDE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConsecutivoHaTiqe)
                    .IsRequired()
                    .HasColumnName("Consecutivo_HA_TIQE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DescSucursal)
                    .IsRequired()
                    .HasColumnName("Desc_Sucursal")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Distrito)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasColumnName("E_mail")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EstatusConsecuivoTiqe)
                    .IsRequired()
                    .HasColumnName("Estatus_Consecuivo_TIQE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusConsecutivoCargaXml)
                    .IsRequired()
                    .HasColumnName("Estatus_Consecutivo_CargaXML")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusConsecutivoFe)
                    .IsRequired()
                    .HasColumnName("Estatus_Consecutivo_FE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusConsecutivoNce)
                    .IsRequired()
                    .HasColumnName("Estatus_Consecutivo_NCE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusConsecutivoNde)
                    .IsRequired()
                    .HasColumnName("Estatus_Consecutivo_NDE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaResolucion)
                    .IsRequired()
                    .HasColumnName("Fecha_Resolucion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrantType)
                    .IsRequired()
                    .HasColumnName("Grant_Type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NoCaja)
                    .IsRequired()
                    .HasColumnName("No_Caja")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NoSucursal)
                    .IsRequired()
                    .HasColumnName("No_Sucursal")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NumeroResolucion)
                    .IsRequired()
                    .HasColumnName("Numero_Resolucion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtroTextFinalLinea)
                    .HasColumnName("Otro_Text_Final_Linea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordToken)
                    .IsRequired()
                    .HasColumnName("Password_Token")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrefijoPais)
                    .IsRequired()
                    .HasColumnName("Prefijo_Pais")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((506))");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Scope)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNumberCertificate)
                    .IsRequired()
                    .HasColumnName("SerialNumber_Certificate")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoIdentificacionEmisor)
                    .IsRequired()
                    .HasColumnName("Tipo_Identificacion_Emisor")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UrlApi)
                    .IsRequired()
                    .HasColumnName("Url_Api")
                    .IsUnicode(false);

                entity.Property(e => e.UrlCallbackUrl)
                    .HasColumnName("Url_CallbackUrl")
                    .IsUnicode(false);

                entity.Property(e => e.UrlToken)
                    .IsRequired()
                    .HasColumnName("Url_Token")
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioToken)
                    .IsRequired()
                    .HasColumnName("Usuario_Token")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCeColaAprobacion>(entity =>
            {
                entity.ToTable("tb_CE_ColaAprobacion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaDoc).HasColumnType("datetime");

                entity.Property(e => e.NumDoc)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TipoDoc)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TbCeComprobantesEnviados>(entity =>
            {
                entity.ToTable("TB_CE_ComprobantesEnviados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConsecutivoHacienda)
                    .IsRequired()
                    .HasColumnName("Consecutivo_Hacienda")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('00000000000000000000')");

                entity.Property(e => e.EstadoEnvio)
                    .IsRequired()
                    .HasColumnName("Estado_Envio")
                    .HasMaxLength(10);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaEmision)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdAjuste)
                    .HasColumnName("id_ajuste")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdFactura).HasColumnName("idFactura");

                entity.Property(e => e.MensajeHacienda)
                    .IsRequired()
                    .HasColumnName("Mensaje_Hacienda")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Moneda)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.NombreReceptor)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.OpcionDePago)
                    .IsRequired()
                    .HasColumnName("Opcion_de_Pago")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PathArchivoPdf)
                    .IsRequired()
                    .HasColumnName("Path_ArchivoPdf")
                    .IsUnicode(false);

                entity.Property(e => e.PathArchivoRespuestaXml)
                    .IsRequired()
                    .HasColumnName("Path_Archivo_RespuestaXml")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PathArchivoRespuestatxt)
                    .IsRequired()
                    .HasColumnName("Path_Archivo_Respuestatxt")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PathArchivoXml)
                    .IsRequired()
                    .HasColumnName("Path_ArchivoXml")
                    .IsUnicode(false);

                entity.Property(e => e.RespuestaHacienda)
                    .IsRequired()
                    .HasColumnName("Respuesta_Hacienda")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TieneNotaCredito).HasColumnName("Tiene_NotaCredito");

                entity.Property(e => e.TieneNotaDebito).HasColumnName("Tiene_NotaDebito");

                entity.Property(e => e.TipoDocElectronico)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TipoNota)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbCeConsecutivoProvisionalHa>(entity =>
            {
                entity.ToTable("TB_CE_ConsecutivoProvisionalHA");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConsecutivoHacienda)
                    .IsRequired()
                    .HasColumnName("Consecutivo_Hacienda")
                    .HasMaxLength(22)
                    .IsUnicode(false);

                entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");

                entity.Property(e => e.NumFactura).HasColumnName("Num_Factura");

                entity.Property(e => e.TipoDocElectronico)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCeDistrito>(entity =>
            {
                entity.HasKey(e => new { e.IdProvincia, e.IdCanton, e.IdDistrito });

                entity.ToTable("TB_CE_Distrito");

                entity.Property(e => e.IdProvincia).HasColumnName("id_Provincia");

                entity.Property(e => e.IdCanton).HasColumnName("id_Canton");

                entity.Property(e => e.IdDistrito).HasColumnName("id_Distrito");

                entity.Property(e => e.DescDistrito)
                    .IsRequired()
                    .HasColumnName("Desc_Distrito")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCeProvincias>(entity =>
            {
                entity.HasKey(e => e.IdProvincia);

                entity.ToTable("TB_CE_Provincias");

                entity.Property(e => e.IdProvincia)
                    .HasColumnName("id_Provincia")
                    .ValueGeneratedNever();

                entity.Property(e => e.DescProvincia)
                    .IsRequired()
                    .HasColumnName("Desc_Provincia")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCeSucursal>(entity =>
            {
                entity.HasKey(e => e.CodSucursal);

                entity.ToTable("TB_CE_Sucursal");

                entity.Property(e => e.CodSucursal).HasColumnName("cod_Sucursal");

                entity.Property(e => e.DescSucursal)
                    .HasColumnName("Desc_Sucursal")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCeTipoIdentificacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoIdentificacion);

                entity.ToTable("TB_CE_TIPO_IDENTIFICACION");

                entity.Property(e => e.IdTipoIdentificacion)
                    .HasColumnName("id_Tipo_Identificacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.DescTipoIdentificacion)
                    .IsRequired()
                    .HasColumnName("Desc_Tipo_Identificacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCeTiposDocElectronicos>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocElectronico);

                entity.ToTable("TB_CE_Tipos_DocElectronicos");

                entity.Property(e => e.IdTipoDocElectronico)
                    .HasColumnName("id_Tipo_DocElectronico")
                    .HasMaxLength(2)
                    .ValueGeneratedNever();

                entity.Property(e => e.DescTipoDocElectronico)
                    .IsRequired()
                    .HasColumnName("Desc_Tipo_DocElectronico")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCoAsientoContable>(entity =>
            {
                entity.HasKey(e => e.IdAsientoContable);

                entity.ToTable("tb_CO_AsientoContable");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaMod).HasColumnType("datetime");

                entity.Property(e => e.Modulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.TbCoAsientoContable)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_CO_AsientoContable_tb_CO_TiposDocumentos");
            });

            modelBuilder.Entity<TbCoAsientoContableDetalle>(entity =>
            {
                entity.HasKey(e => e.IdDetalleAsientoContable)
                    .HasName("PK_Tb_CO_DetalleAsientoContable");

                entity.ToTable("tb_CO_AsientoContableDetalle");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(800);

                entity.HasOne(d => d.IdAsientoContableNavigation)
                    .WithMany(p => p.TbCoAsientoContableDetalle)
                    .HasForeignKey(d => d.IdAsientoContable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb_CO_DetalleAsientoContable_tb_CO_AsientoContable");

                entity.HasOne(d => d.IdCuentaContableNavigation)
                    .WithMany(p => p.TbCoAsientoContableDetalle)
                    .HasForeignKey(d => d.IdCuentaContable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb_CO_DetalleAsientoContable_tb_CO_CuentaContable");
            });

            modelBuilder.Entity<TbCoCentrosDeGastos>(entity =>
            {
                entity.ToTable("tb_CO_CentrosDeGastos");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaMod).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observacion).HasMaxLength(200);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<TbCoConfiguracion>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracion)
                    .HasName("PK_Tb_CO_Configuracion");

                entity.ToTable("tb_CO_Configuracion");

                entity.Property(e => e.Ejemplo).HasMaxLength(50);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaDesde).HasMaxLength(50);

                entity.Property(e => e.FechaHasta).HasMaxLength(50);
            });

            modelBuilder.Entity<TbCoCuentaContable>(entity =>
            {
                entity.ToTable("tb_CO_CuentaContable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CuentaContable)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaContablePresupuesto)
                    .IsRequired()
                    .HasColumnName("CuentaContable_Presupuesto")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaMadre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescCuentaMadre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DescTipoCompra)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Moneda)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('NOMINAL')");

                entity.Property(e => e.Notas)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Parentid).HasColumnName("PARENTID");

                entity.Property(e => e.PermisoAcF)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermisoBancos)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermisoCheque)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermisoConf)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermisoCont)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermisoCxC)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermisoCxP)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermisoFac)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermisoGas)
                    .IsRequired()
                    .HasColumnName("PermisoGAS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermisoInv)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PermisoPla)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TipoConversion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('CONVERSION')");
            });

            modelBuilder.Entity<TbCoPeriodoFiscal>(entity =>
            {
                entity.HasKey(e => e.IdPeriodoFiscal);

                entity.ToTable("tb_CO_PeriodoFiscal");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaDesde).HasColumnType("datetime");

                entity.Property(e => e.FechaHasta).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbCoPeriodoTrabajo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodoTrabajo);

                entity.ToTable("tb_CO_PeriodoTrabajo");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdPeriodoFiscalNavigation)
                    .WithMany(p => p.TbCoPeriodoTrabajo)
                    .HasForeignKey(d => d.IdPeriodoFiscal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_CO_PeriodoTrabajo_tb_CO_PeriodoFiscal");
            });

            modelBuilder.Entity<TbCoSetting>(entity =>
            {
                entity.HasKey(e => e.IdSetting)
                    .HasName("PK_tb_Co_Setting");

                entity.ToTable("tb_CO_Setting");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.TipoReferencia).HasMaxLength(100);
            });

            modelBuilder.Entity<TbCoSettingTipo>(entity =>
            {
                entity.HasKey(e => e.IdTipoSetting);

                entity.ToTable("tb_CO_SettingTipo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Observacion).HasMaxLength(100);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TipoCuentaContable).HasMaxLength(100);
            });

            modelBuilder.Entity<TbCoTipoCuenta>(entity =>
            {
                entity.HasKey(e => e.IdTipoCuenta);

                entity.ToTable("tb_CO_TipoCuenta");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumeroCuenta)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbCoTiposDocumentos>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento);

                entity.ToTable("tb_CO_TiposDocumentos");

                entity.Property(e => e.Abreviatura)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbCoUtilidadRenta>(entity =>
            {
                entity.ToTable("tb_CO_UtilidadRenta");

                entity.Property(e => e.Tccd).HasColumnName("TCCD");

                entity.Property(e => e.Tcce).HasColumnName("TCCE");

                entity.Property(e => e.Tcvd).HasColumnName("TCVD");

                entity.Property(e => e.Tcve).HasColumnName("TCVE");
            });

            modelBuilder.Entity<TbCpCategoriaGasto>(entity =>
            {
                entity.ToTable("tb_CP_CategoriaGasto");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });


            modelBuilder.Entity<TbCpComprasDetalleServicio>(entity =>
            {
                entity.HasKey(e => e.IdCompraDetalle);

                entity.ToTable("tb_CP_ComprasDetalleServicio");

                entity.Property(e => e.Articulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PorcIva).HasColumnName("PorcIVA");

                entity.Property(e => e.SubTotalGravadoEuro).HasColumnName("subTotalGravadoEuro");

                entity.Property(e => e.TotalIsbase).HasColumnName("TotalISBase");

                entity.Property(e => e.TotalIsdolar).HasColumnName("TotalISDolar");

                entity.Property(e => e.TotalIseuro).HasColumnName("TotalISEuro");

                entity.Property(e => e.TotalIvabase).HasColumnName("TotalIVABase");

                entity.Property(e => e.TotalIvadolar).HasColumnName("TotalIVADolar");

                entity.Property(e => e.TotalIvaeuro).HasColumnName("TotalIVAEuro");

                entity.HasOne(d => d.IdCategoriaGastoNavigation)
                    .WithMany(p => p.TbCpComprasDetalleServicio)
                    .HasForeignKey(d => d.IdCategoriaGasto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_CP_ComprasDetalleServicio_tb_CP_CategoriaGasto");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.TbCpComprasDetalleServicio)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_CP_ComprasDetalleServicio_tb_PR_Compra");
            });

            modelBuilder.Entity<TbCrCamposPersonalizados>(entity =>
            {
                entity.ToTable("tb_CR_CamposPersonalizados");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCrContacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto)
                    .HasName("PK_tb_SE_Contacto");

                entity.ToTable("tb_CR_Contacto");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.MapLink)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreComercial)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreJuridico)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OtrasSenas)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ruta)
                    .IsRequired()
                    .HasColumnName("ruta")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoCedula)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WebLink)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbCrContactoRelacion>(entity =>
            {
                entity.ToTable("Tb_CR_ContactoRelacion");

                entity.Property(e => e.NotaRelacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContactoHijoNavigation)
                    .WithMany(p => p.TbCrContactoRelacionIdContactoHijoNavigation)
                    .HasForeignKey(d => d.IdContactoHijo)
                    .HasConstraintName("FK_Tb_Cr_ContactoRelacion_tb_CR_Contacto1");

                entity.HasOne(d => d.IdContactoPadreNavigation)
                    .WithMany(p => p.TbCrContactoRelacionIdContactoPadreNavigation)
                    .HasForeignKey(d => d.IdContactoPadre)
                    .HasConstraintName("FK_Tb_Cr_ContactoRelacion_tb_CR_Contacto");
            });

            modelBuilder.Entity<TbCrContactosCamposPersonalizados>(entity =>
            {
                entity.ToTable("tb_CR_ContactosCamposPersonalizados");

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasColumnName("valor")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdCampoPersonalizadosNavigation)
                    .WithMany(p => p.TbCrContactosCamposPersonalizados)
                    .HasForeignKey(d => d.IdCampoPersonalizados)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_CR_ContactosCamposPersonalizados_tb_CR_CamposPersonalizados");

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.TbCrContactosCamposPersonalizados)
                    .HasForeignKey(d => d.IdContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_CR_ContactosCamposPersonalizados_tb_CR_Contacto");
            });

            modelBuilder.Entity<TbCrListaDesplegables>(entity =>
            {
                entity.ToTable("TB_CR_ListaDesplegables");

                entity.Property(e => e.Valor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCamposPersonalizadosNavigation)
                    .WithMany(p => p.TbCrListaDesplegables)
                    .HasForeignKey(d => d.IdCamposPersonalizados)
                    .HasConstraintName("FK_TB_CR_ListaDesplegables_tb_CR_CamposPersonalizados");
            });

            modelBuilder.Entity<TbFaCaja>(entity =>
            {
                entity.HasKey(e => e.IdCaja);

                entity.ToTable("tb_FA_Caja");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdPuntoVentaNavigation)
                    .WithMany(p => p.TbFaCaja)
                    .HasForeignKey(d => d.IdPuntoVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_Caja_tb_SE_PuntoVenta");
            });

            modelBuilder.Entity<TbFaCajaAperturaDenominacion>(entity =>
            {
                entity.HasKey(e => e.IdCajaApertura);

                entity.ToTable("tb_FA_CajaAperturaDenominacion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaAperturaDenominacion)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaAperturaDenominacion_tb_FA_Caja");

                entity.HasOne(d => d.IdDenominacionNavigation)
                    .WithMany(p => p.TbFaCajaAperturaDenominacion)
                    .HasForeignKey(d => d.IdDenominacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaAperturaDenominacion_tb_FA_Denominacion");
            });

            modelBuilder.Entity<TbFaCajaArqueo>(entity =>
            {
                entity.HasKey(e => e.IdCajaArqueo);

                entity.ToTable("tb_FA_CajaArqueo");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaArqueo)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaArqueo_tb_FA_CajaArqueo");
            });

            modelBuilder.Entity<TbFaCajaArqueoDenominacion>(entity =>
            {
                entity.HasKey(e => e.IdCajaArqueoDenominacion);

                entity.ToTable("tb_FA_CajaArqueoDenominacion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaArqueoDenominacion)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaArqueoDenominacion_tb_FA_Caja");

                entity.HasOne(d => d.IdDenominacionNavigation)
                    .WithMany(p => p.TbFaCajaArqueoDenominacion)
                    .HasForeignKey(d => d.IdDenominacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaArqueoDenominacion_tb_FA_Denominacion");
            });

            modelBuilder.Entity<TbFaCajaArqueoOperadorTarjeta>(entity =>
            {
                entity.HasKey(e => e.IdCajaArqueoOperadorTarjeta);

                entity.ToTable("tb_FA_CajaArqueoOperadorTarjeta");

                entity.Property(e => e.NumeroCierre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaArqueoOperadorTarjeta)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaArqueoOperadorTarjeta_tb_FA_Caja");

                entity.HasOne(d => d.IdFlujoCategoriaNavigation)
                    .WithMany(p => p.TbFaCajaArqueoOperadorTarjeta)
                    .HasForeignKey(d => d.IdFlujoCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaArqueoOperadorTarjeta_tb_BA_FlujoCategoria");
            });

            modelBuilder.Entity<TbFaCajaCierre>(entity =>
            {
                entity.HasKey(e => e.IdCajaCierre)
                    .HasName("PK_tb_FA_CajaCierre+");

                entity.ToTable("tb_FA_CajaCierre");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaCierre)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaCierre_tb_FA_Caja");
            });

            modelBuilder.Entity<TbFaMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento);

                entity.ToTable("tb_FA_Movimiento");

                entity.Property(e => e.Cxc).HasColumnName("CXC");

                entity.Property(e => e.Cxp).HasColumnName("CXP");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaldoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaldoDolar).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.TbFaMovimiento)
                    .HasForeignKey(d => d.IdContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_Movimiento_tb_CR_Contacto");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.TbFaMovimiento)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_Movimiento_tb_FA_TipoDocumento");
            });

            modelBuilder.Entity<TbFaCajaMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdCajaMovimiento);

                entity.ToTable("tb_FA_CajaMovimiento");

                entity.Property(e => e.CompraDolarTc).HasColumnName("CompraDolarTC");

                entity.Property(e => e.CompraEuroTc).HasColumnName("CompraEuroTC");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.VentaDolarTc).HasColumnName("VentaDolarTC");

                entity.Property(e => e.VentaEuroTc).HasColumnName("VentaEuroTC");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaMovimiento)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimiento_tb_FA_Caja");

                entity.HasOne(d => d.IdCategoriaFlujoNavigation)
                    .WithMany(p => p.TbFaCajaMovimiento)
                    .HasForeignKey(d => d.IdCategoriaFlujo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimiento_tb_BA_FlujoCategoria");

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.TbFaCajaMovimiento)
                    .HasForeignKey(d => d.IdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimiento_tb_FA_Movimiento");
            });

            modelBuilder.Entity<TbFaCajaMovimientoFlujo>(entity =>
            {
                entity.HasKey(e => e.IdCajaMovimientoFlujo);

                entity.ToTable("tb_FA_CajaMovimientoFlujo");

                entity.HasOne(d => d.IdCajaMovimientoNavigation)
                    .WithMany(p => p.TbFaCajaMovimientoFlujo)
                    .HasForeignKey(d => d.IdCajaMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimientoFlujo_tb_FA_CajaMovimiento");

                entity.HasOne(d => d.IdFlujoNavigation)
                    .WithMany(p => p.TbFaCajaMovimientoFlujo)
                    .HasForeignKey(d => d.IdFlujo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimientoFlujo_tb_BA_Flujo");
            });

            modelBuilder.Entity<TbFaCajaMovimientoCheque>(entity =>
            {
                entity.HasKey(e => e.IdCajaMovimientoCheque);

                entity.ToTable("tb_FA_CajaMovimientoCheque");

                entity.Property(e => e.Banco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Portador)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdCajaMovimientoNavigation)
                    .WithMany(p => p.TbFaCajaMovimientoCheque)
                    .HasForeignKey(d => d.IdCajaMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimientoCheque_tb_FA_CajaMovimiento");
            });

            modelBuilder.Entity<TbFaCajaMovimientoTarjeta>(entity =>
            {
                entity.HasKey(e => e.IdCajaMovimientoTarjeta);

                entity.ToTable("tb_FA_CajaMovimientoTarjeta");

                entity.Property(e => e.Autorizacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Voucher)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCajaMovimientoNavigation)
                    .WithMany(p => p.TbFaCajaMovimientoTarjeta)
                    .HasForeignKey(d => d.IdCajaMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimientoTarjeta_tb_FA_CajaMovimiento");
            });

            modelBuilder.Entity<TbFaCotizacion>(entity =>
            {
                entity.HasKey(e => e.IdCotizacion);

                entity.ToTable("Tb_FA_Cotizacion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaCotizacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.MontoIvabase).HasColumnName("MontoIVABase");

                entity.Property(e => e.MontoIvadolar).HasColumnName("MontoIVADolar");

                entity.Property(e => e.MontoIvaeuro).HasColumnName("MontoIVAEuro");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbFaCotizacion)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb_FA_Cotizacion_tb_CR_Contacto");
            });

            modelBuilder.Entity<TbFaCotizacionConfig>(entity =>
            {
                entity.HasKey(e => e.IdCotizacionConfig);

                entity.ToTable("Tb_FA_CotizacionConfig");

                entity.Property(e => e.IdMonedaDefecto).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TbFaCotizacionDetalle>(entity =>
            {
                entity.HasKey(e => e.IdCotizacionDetalle);

                entity.ToTable("Tb_FA_CotizacionDetalle");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MontoIvaBase).HasColumnName("MontoIVABase");

                entity.Property(e => e.MontoIvaDolar).HasColumnName("MontoIVADolar");

                entity.Property(e => e.MontoIvaEuro).HasColumnName("MontoIVAEuro");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.TbFaCotizacionDetalle)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb_FA_CotizacionDetalle_tb_PR_Inventario");
            });

            modelBuilder.Entity<TbFaDenominacion>(entity =>
            {
                entity.HasKey(e => e.IdDenominaciones)
                    .HasName("PK_tb_FA_Denominacion_1");

                entity.ToTable("tb_FA_Denominacion");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tipo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Valor).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TbFaDescuentoProducto>(entity =>
            {
                entity.HasKey(e => e.IdDescuentoProducto);

                entity.ToTable("Tb_FA_DescuentoProducto");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('(\"Tipo 1\")')");
            });

            modelBuilder.Entity<TbFaDescuentoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdDescuentoUsuario);

                entity.ToTable("Tb_FA_DescuentoUsuario");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRebajaConfigNavigation)
                    .WithMany(p => p.TbFaDescuentoUsuario)
                    .HasForeignKey(d => d.IdRebajaConfig)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb_FA_DescuentoUsuario_Tb_FA_RebajaConfig");
            });

            modelBuilder.Entity<TbFaDescuentoUsuarioClave>(entity =>
            {
                entity.HasKey(e => e.IdDescuentoUsuario);

                entity.ToTable("Tb_FA_DescuentoUsuarioClave");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRebajaConfigNavigation)
                    .WithMany(p => p.TbFaDescuentoUsuarioClave)
                    .HasForeignKey(d => d.IdRebajaConfig)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb_FA_DescuentoUsuarioClave_Tb_FA_RebajaConfig");
            });

            modelBuilder.Entity<TbFaDescuentoUsuarioRango>(entity =>
            {
                entity.HasKey(e => e.IdDescuentoUsuarioRango);

                entity.ToTable("Tb_FA_DescuentoUsuarioRango");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaDesde)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaHasta)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('((\" \"))')");

                entity.HasOne(d => d.IdRebajaConfigNavigation)
                    .WithMany(p => p.TbFaDescuentoUsuarioRango)
                    .HasForeignKey(d => d.IdRebajaConfig)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb_FA_DescuentoUsuarioRango_Tb_FA_RebajaConfig");
            });

            modelBuilder.Entity<TbFaMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento);

                entity.ToTable("tb_FA_Movimiento");

                entity.Property(e => e.Cxc).HasColumnName("CXC");

                entity.Property(e => e.Cxp).HasColumnName("CXP");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.TbFaMovimiento)
                    .HasForeignKey(d => d.IdContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_Movimiento_tb_CR_Contacto");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.TbFaMovimiento)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_Movimiento_tb_FA_TipoDocumento");
            });

            modelBuilder.Entity<TbFaMovimientoDetalle>(entity =>
            {
                entity.HasKey(e => e.IdMovimientoDetalle);

                entity.ToTable("tb_FA_MovimientoDetalle");

                entity.Property(e => e.CompraDolarTc).HasColumnName("CompraDolarTC");

                entity.Property(e => e.CompraEuroTc).HasColumnName("CompraEuroTC");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VentaDolarTc).HasColumnName("VentaDolarTC");

                entity.Property(e => e.VentaEuroTc).HasColumnName("VentaEuroTC");

                entity.HasOne(d => d.IdMovimientoDesdeNavigation)
                    .WithMany(p => p.TbFaMovimientoDetalleIdMovimientoDesdeNavigation)
                    .HasForeignKey(d => d.IdMovimientoDesde)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_MovimientoDetalle_tb_FA_Movimiento");

                entity.HasOne(d => d.IdMovimientoHastaNavigation)
                    .WithMany(p => p.TbFaMovimientoDetalleIdMovimientoHastaNavigation)
                    .HasForeignKey(d => d.IdMovimientoHasta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_MovimientoDetalle_tb_FA_Movimiento1");
            });

            modelBuilder.Entity<TbFaMovimientoJustificante>(entity =>
            {
                entity.HasKey(e => e.IdMovimientoJustificante);

                entity.ToTable("tb_FA_MovimientoJustificante");

                entity.Property(e => e.CompraDolarTc).HasColumnName("CompraDolarTC");

                entity.Property(e => e.CompraEuroTc).HasColumnName("CompraEuroTC");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.VentaDolatTc).HasColumnName("VentaDolatTC");

                entity.Property(e => e.VentaEuroTc).HasColumnName("VentaEuroTC");

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.TbFaMovimientoJustificante)
                    .HasForeignKey(d => d.IdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_MovimientoJustificante_tb_FA_Movimiento");

                entity.HasOne(d => d.IdTipoJustificanteNavigation)
                    .WithMany(p => p.TbFaMovimientoJustificante)
                    .HasForeignKey(d => d.IdTipoJustificante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_MovimientoJustificante_tb_FA_TipoJustificante");
            });

            modelBuilder.Entity<TbFaPago>(entity =>
            {
                entity.HasKey(e => e.IdPago);

                entity.ToTable("tb_FA_Pago");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.TbFaPago)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_Pago_tb_FA_TipoDocumento");
            });

            modelBuilder.Entity<TbFaPromocionProducto>(entity =>
            {
                entity.HasKey(e => e.IdPromocionProducto);

                entity.ToTable("Tb_FA_PromocionProducto");

                entity.Property(e => e.CantTipo1Promo).HasDefaultValueSql("((1))");

                entity.Property(e => e.CantTipo1Ref).HasDefaultValueSql("((1))");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EsTipo2)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaDesde).HasColumnType("datetime");

                entity.Property(e => e.FechaHasta).HasColumnType("datetime");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdRebajaConfigNavigation)
                    .WithMany(p => p.TbFaPromocionProducto)
                    .HasForeignKey(d => d.IdRebajaConfig)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tb_FA_PromocionProducto_Tb_FA_RebajaConfig");
            });

            modelBuilder.Entity<TbFaRebajaConfig>(entity =>
            {
                entity.HasKey(e => e.IdRebajaConfig);

                entity.ToTable("Tb_FA_RebajaConfig");
            });

            modelBuilder.Entity<TbFaTipoCajaMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdTipoCajaMovimiento);

                entity.ToTable("tb_FA_TipoCajaMovimiento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFaTipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento);

                entity.ToTable("tb_FA_TipoDocumento");

                entity.Property(e => e.Cxc).HasColumnName("CXC");

                entity.Property(e => e.EsDebito).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFaTipoJustificante>(entity =>
            {
                entity.HasKey(e => e.IdTipoJustificante);

                entity.ToTable("tb_FA_TipoJustificante");

                entity.Property(e => e.Cxc)
                    .IsRequired()
                    .HasColumnName("CXC")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cxp)
                    .IsRequired()
                    .HasColumnName("CXP")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TbFdCondicionesDePago>(entity =>
            {
                entity.ToTable("TB_FD_CondicionesDePago");

                entity.Property(e => e.EsCliente).HasColumnName("esCliente");

                entity.Property(e => e.EsProveedor).HasColumnName("esProveedor");

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.TbFdCondicionesDePago)
                    .HasForeignKey(d => d.IdContacto)
                    .HasConstraintName("FK_TB_FD_CondicionesDePago_tb_CR_Contacto");
            });

            modelBuilder.Entity<TbFdConfiguracionFiltros>(entity =>
            {
                entity.ToTable("tb_FD_ConfiguracionFiltros");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TbFdCuentasBancarias>(entity =>
            {
                entity.ToTable("TB_FD_CuentasBancarias");

                entity.Property(e => e.Banco)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaBancaria)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Moneda)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCuenta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.TbFdCuentasBancarias)
                    .HasForeignKey(d => d.IdContacto)
                    .HasConstraintName("FK_TB_FD_CuentasBancarias_tb_CR_Contacto");
            });

            modelBuilder.Entity<TbFdFactura>(entity =>
            {
                entity.ToTable("tb_FD_Factura");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaFactura)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate()+(30))");

                entity.Property(e => e.MontoIvabase).HasColumnName("MontoIVABase");

                entity.Property(e => e.MontoIvadolar).HasColumnName("MontoIVADolar");

                entity.Property(e => e.MontoIvaeuro).HasColumnName("MontoIVAEuro");

                entity.Property(e => e.Tipo).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbFdFactura)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Factura_tb_CR_Contacto");

                entity.HasOne(d => d.IdPuntoVentaNavigation)
                    .WithMany(p => p.TbFdFactura)
                    .HasForeignKey(d => d.IdPuntoVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Factura_tb_SE_PuntoVenta");
            });

            modelBuilder.Entity<TbFdFacturaDetalle>(entity =>
            {
                entity.ToTable("tb_FD_FacturaDetalle");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate()+(30))");

                entity.Property(e => e.MontoIvabase).HasColumnName("MontoIVABase");

                entity.Property(e => e.MontoIvadolar).HasColumnName("MontoIVADolar");

                entity.Property(e => e.MontoIvaeuro).HasColumnName("MontoIVAEuro");

                entity.Property(e => e.PorcIva).HasColumnName("PorcIVA");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.TbFdFacturaDetalle)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_FacturaDetalle_tb_FD_Factura");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbFdFacturaDetalle)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_FacturaDetalle_tb_PR_Inventario");
            });

            modelBuilder.Entity<TbFdSubtareas>(entity =>
            {
                entity.ToTable("TB_FD_Subtareas");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTareaNavigation)
                    .WithMany(p => p.TbFdSubtareas)
                    .HasForeignKey(d => d.IdTarea)
                    .HasConstraintName("FK_SubTareas_Tareas");
            });

            modelBuilder.Entity<TbFdTarea>(entity =>
            {
                entity.ToTable("tb_FD_Tarea");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.FechaLimite).HasColumnType("datetime");

                entity.Property(e => e.IdContacto).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((0))");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.TbFdTarea)
                    .HasForeignKey(d => d.IdContacto)
                    .HasConstraintName("FK_tb_FD_Tarea_tb_CR_Contacto");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.TbFdTarea)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_tb_FD_Tarea_FD_TareaEstado");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.TbFdTarea)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK_tb_FD_Tarea_tb_FD_TareaTipo");
            });

            modelBuilder.Entity<TbFdTareaEstado>(entity =>
            {
                entity.ToTable("tb_FD_TareaEstado");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbFdTareaTipo>(entity =>
            {
                entity.ToTable("tb_FD_TareaTipo");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbFdTipoCliente>(entity =>
            {
                entity.ToTable("TB_FD_TipoCliente");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdTipoPrecioNavigation)
                    .WithMany(p => p.TbFdTipoCliente)
                    .HasForeignKey(d => d.IdTipoPrecio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_FD_TipoCliente_tb_PR_Precios");
            });

            modelBuilder.Entity<TbFdTipoProveedor>(entity =>
            {
                entity.ToTable("TB_FD_TipoProveedor");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbPrAjuste>(entity =>
            {
                entity.ToTable("tb_PR_Ajuste");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((15)/(1))/(2015))");

                entity.Property(e => e.FechaDocumento).HasColumnType("datetime");

                entity.HasOne(d => d.IdBodegaNavigation)
                    .WithMany(p => p.TbPrAjuste)
                    .HasForeignKey(d => d.IdBodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Ajuste_tb_PR_Bodega");
            });

            modelBuilder.Entity<TbPrAjusteInventario>(entity =>
            {
                entity.ToTable("tb_PR_AjusteInventario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAjusteNavigation)
                    .WithMany(p => p.TbPrAjusteInventario)
                    .HasForeignKey(d => d.IdAjuste)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_AjusteInventario_tb_PR_Ajuste");

                entity.HasOne(d => d.IdCentroGastosNavigation)
                    .WithMany(p => p.TbPrAjusteInventario)
                    .HasForeignKey(d => d.IdCentroGastos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_AjusteInventario_tb_CO_CentrosDeGastos");

                entity.HasOne(d => d.IdCuentaContableNavigation)
                    .WithMany(p => p.TbPrAjusteInventario)
                    .HasForeignKey(d => d.IdCuentaContable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_AjusteInventario_tb_CO_CuentaContable");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrAjusteInventario)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_AjusteInventario_tb_PR_Inventario");
            });

            modelBuilder.Entity<TbPrBodega>(entity =>
            {
                entity.ToTable("tb_PR_Bodega");

                entity.Property(e => e.Almacenamiento)
                 .IsRequired()
                 .HasDefaultValueSql("((1))");

                entity.Property(e => e.Consignacion)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observaciones).HasMaxLength(200);

                entity.Property(e => e.Produccion)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SuministrosInternos)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TbPrCompra>(entity =>
            {
                entity.ToTable("tb_PR_Compra");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaDocumento).HasColumnType("datetime");

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TotalFabase).HasColumnName("TotalFABase");

                entity.Property(e => e.TotalFadolar).HasColumnName("TotalFADolar");

                entity.Property(e => e.TotalFaeuro).HasColumnName("TotalFAEuro");

                entity.Property(e => e.TotalIvabase).HasColumnName("TotalIVABase");

                entity.Property(e => e.TotalIvadolar).HasColumnName("TotalIVADolar");

                entity.Property(e => e.TotalIvaeuro).HasColumnName("TotalIVAEuro");

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.TbPrCompra)
                    .HasForeignKey(d => d.IdContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Compra_tb_CR_Contacto");
            });

            modelBuilder.Entity<TbPrCompraDetalle>(entity =>
            {
                entity.ToTable("tb_PR_CompraDetalle");

                entity.Property(e => e.PorcFa).HasColumnName("PorcFA");

                entity.Property(e => e.PorcIva).HasColumnName("PorcIVA");

                entity.Property(e => e.TotalFabase).HasColumnName("TotalFABase");

                entity.Property(e => e.TotalFadolar).HasColumnName("TotalFADolar");

                entity.Property(e => e.TotalFaeuro).HasColumnName("TotalFAEuro");

                entity.Property(e => e.TotalIvabase).HasColumnName("TotalIVABase");

                entity.Property(e => e.TotalIvadolar).HasColumnName("TotalIVADolar");

                entity.Property(e => e.TotalIvaeuro).HasColumnName("TotalIVAEuro");

                entity.HasOne(d => d.IdBodegaNavigation)
                    .WithMany(p => p.TbPrCompraDetalle)
                    .HasForeignKey(d => d.IdBodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_CompraDetalle_tb_PR_Bodega");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.TbPrCompraDetalle)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_CompraDetalle_tb_PR_Compra");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrCompraDetalle)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_CompraDetalle_tb_PR_Inventario");
            });

            modelBuilder.Entity<TbPrConversion>(entity =>
            {
                entity.HasKey(e => e.IdConversion);

                entity.ToTable("tb_PR_Conversion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUnidadDestino).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdUnidadOrigen).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdUnidadDestinoNavigation)
                    .WithMany(p => p.TbPrConversionIdUnidadDestinoNavigation)
                    .HasForeignKey(d => d.IdUnidadDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Conversion_tb_PR_UnidadMedida1");

                entity.HasOne(d => d.IdUnidadOrigenNavigation)
                    .WithMany(p => p.TbPrConversionIdUnidadOrigenNavigation)
                    .HasForeignKey(d => d.IdUnidadOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Conversion_tb_PR_UnidadMedida");
            });

            modelBuilder.Entity<TbPrDepartamento>(entity =>
            {
                entity.ToTable("tb_PR_Departamento");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPrEquivalencia>(entity =>
            {
                entity.ToTable("tb_PR_Equivalencia");

                entity.Property(e => e.Observaciones).HasMaxLength(250);

                entity.Property(e => e.Unilateral).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdEquivalenciaNavigation)
                    .WithMany(p => p.TbPrEquivalenciaIdEquivalenciaNavigation)
                    .HasForeignKey(d => d.IdEquivalencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Equivalencia_tb_PR_Inventario1");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrEquivalenciaIdInventarioNavigation)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Equivalencia_tb_PR_Inventario");
            });

            modelBuilder.Entity<TbPrFamilia>(entity =>
            {
                entity.ToTable("tb_PR_Familia");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdFamiliaNavigation)
                    .WithMany(p => p.InverseIdFamiliaNavigation)
                    .HasForeignKey(d => d.IdFamilia)
                    .HasConstraintName("FK_tb_PR_Familia_tb_PR_Familia");
            });

            modelBuilder.Entity<TbPrFamiliaVentaOnline>(entity =>
            {
                entity.ToTable("TB_PR_FamiliaVentaOnline");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdFamiliaNavigation)
                    .WithMany(p => p.InverseIdFamiliaNavigation)
                    .HasForeignKey(d => d.IdFamilia)
                    .HasConstraintName("FK_TB_PR_FamiliaVentaOnline_TB_PR_FamiliaVentaOnline");
            });

            modelBuilder.Entity<TbPrImagenInventario>(entity =>
            {
                entity.HasKey(e => e.IdImagen);

                entity.ToTable("tb_PR_ImagenInventario");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrImagenInventario)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_ImagenInventario_tb_PR_Inventario");
            });

            modelBuilder.Entity<TbPrInformacionBancaria>(entity =>
            {
                entity.ToTable("tb_PR_InformacionBancaria");

                entity.Property(e => e.CuentaBanco)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.CuentaCliente)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.NombreBanco)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");
            });

            modelBuilder.Entity<TbPrInventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario);

                entity.ToTable("tb_PR_Inventario");

                entity.Property(e => e.AbreviacionFacturas)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.CodigoMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.CodigoMonedaVenta).HasDefaultValueSql("((2))");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.DescripcionVenta)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMonedaVentaOnline).HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreCarrito)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.Notas)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.SkuOnline)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdSubFamiliaNavigation)
                    .WithMany(p => p.TbPrInventario)
                    .HasForeignKey(d => d.IdSubFamilia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Inventario_tb_PR_Familia");

                entity.HasOne(d => d.IdUnidadMedidaNavigation)
                    .WithMany(p => p.TbPrInventario)
                    .HasForeignKey(d => d.IdUnidadMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Inventario_tb_PR_UnidadMedida");
            });

            modelBuilder.Entity<TbPrInventarioBodega>(entity =>
            {
                entity.ToTable("tb_PR_InventarioBodega");

                entity.HasOne(d => d.IdBodegaNavigation)
                    .WithMany(p => p.TbPrInventarioBodega)
                    .HasForeignKey(d => d.IdBodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_InventarioBodega_tb_PR_Bodega");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrInventarioBodega)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_InventarioBodega_tb_PR_Inventario");
            });

            modelBuilder.Entity<TbPrInventarioCaracteristica>(entity =>
            {
                entity.HasKey(e => e.IdCaracteristicas);

                entity.ToTable("tb_PR_InventarioCaracteristica");

                entity.Property(e => e.Caracteristicas)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrInventarioCaracteristica)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_InventarioCaracteristica_tb_PR_Inventario");
            });

            modelBuilder.Entity<TbPrKardex>(entity =>
            {
                entity.ToTable("tb_PR_Kardex");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");
            });

            modelBuilder.Entity<TbPrOrden>(entity =>
            {
                entity.ToTable("tb_PR_Orden");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TotalIvabase).HasColumnName("TotalIVABase");

                entity.Property(e => e.TotalIvadolar).HasColumnName("TotalIVADolar");

                entity.Property(e => e.TotalIvaeuro).HasColumnName("TotalIVAEuro");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.TbPrOrden)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Orden_tb_PR_Contacto");
            });

            modelBuilder.Entity<TbPrOrdenDetalle>(entity =>
            {
                entity.ToTable("tb_PR_OrdenDetalle");

                entity.Property(e => e.NombreInventario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PorcIs).HasColumnName("PorcIS");

                entity.Property(e => e.PorcIva).HasColumnName("PorcIVA");

                entity.Property(e => e.TotalIsbase).HasColumnName("TotalISBase");

                entity.Property(e => e.TotalIsdolar).HasColumnName("TotalISDolar");

                entity.Property(e => e.TotalIseuro).HasColumnName("TotalISEuro");

                entity.Property(e => e.TotalIvabase).HasColumnName("TotalIVABase");

                entity.Property(e => e.TotalIvadolar).HasColumnName("TotalIVADolar");

                entity.Property(e => e.TotalIvaeuro).HasColumnName("TotalIVAEuro");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrOrdenDetalle)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_OrdenDetalle_tb_PR_Inventario");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.TbPrOrdenDetalle)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_OrdenDetalle_tb_PR_Orden");
            });

            modelBuilder.Entity<TbPrPrecioCatalogo>(entity =>
            {
                entity.HasKey(e => e.IdPrecioCatalogo);

                entity.ToTable("tb_PR_PrecioCatalogo");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrPrecioCatalogo)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_PrecioCatalogo_tb_PR_Inventario");

                entity.HasOne(d => d.IdTipoPrecioNavigation)
                    .WithMany(p => p.TbPrPrecioCatalogo)
                    .HasForeignKey(d => d.IdTipoPrecio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_PrecioCatalogo_tb_PR_Precios");
            });

            modelBuilder.Entity<TbPrPrecios>(entity =>
            {
                entity.ToTable("tb_PR_Precios");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbPrPreciosInventarios>(entity =>
            {
                entity.ToTable("tb_PR_PreciosInventarios");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TbPrPreciosInventariosAutomaticos>(entity =>
            {
                entity.ToTable("tb_PR_PreciosInventariosAutomaticos");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbPrPreciosInventariosAutomaticosDetalle>(entity =>
            {
                entity.ToTable("tb_PR_PreciosInventariosAutomaticosDetalle");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TbPrPreciosInventariosDetalle>(entity =>
            {
                entity.ToTable("tb_PR_PreciosInventariosDetalle");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TbPrRequisicion>(entity =>
            {
                entity.ToTable("tb_PR_Requisicion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdBodegaNavigation)
                    .WithMany(p => p.TbPrRequisicion)
                    .HasForeignKey(d => d.IdBodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Requisicion_tb_PR_Bodega");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.TbPrRequisicion)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Requisicion_tb_PR_Departamento");
            });

            modelBuilder.Entity<TbPrRequisicionDetalle>(entity =>
            {
                entity.ToTable("tb_PR_RequisicionDetalle");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrRequisicionDetalle)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_RequisicionDetalle_tb_PR_Inventario");

                entity.HasOne(d => d.IdRequisicionNavigation)
                    .WithMany(p => p.TbPrRequisicionDetalle)
                    .HasForeignKey(d => d.IdRequisicion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_RequisicionInventario_tb_PR_Requisiciones1");
            });

            modelBuilder.Entity<TbPrTipoProveedor>(entity =>
            {
                entity.HasKey(e => e.IdTipoProveedor);

                entity.ToTable("tb_PR_TipoProveedor");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TbPrToma>(entity =>
            {
                entity.ToTable("tb_PR_Toma");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaToma).HasColumnType("datetime");

                entity.Property(e => e.Ordenado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBodegaNavigation)
                    .WithMany(p => p.TbPrToma)
                    .HasForeignKey(d => d.IdBodega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Toma_tb_PR_Bodega");
            });

            modelBuilder.Entity<TbPrTomaDetalle>(entity =>
            {
                entity.ToTable("tb_PR_TomaDetalle");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrTomaDetalle)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_TomaDetalle_tb_PR_Inventario");

                entity.HasOne(d => d.IdTomaNavigation)
                    .WithMany(p => p.TbPrTomaDetalle)
                    .HasForeignKey(d => d.IdToma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_TomaDetalle_tb_PR_Toma");
            });


            modelBuilder.Entity<TbPrUnidadMedida>(entity =>
            {
                entity.ToTable("tb_PR_UnidadMedida");

                entity.Property(e => e.Abreviatura)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSeConfiguracion>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracion);

                entity.ToTable("tb_SE_Configuracion");

                entity.Property(e => e.Alottemets)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('FF80FF80')");

                entity.Property(e => e.CedulaJuridica)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodigoMonedaFactura).HasDefaultValueSql("((2))");

                entity.Property(e => e.CodigoMonedaTarifas).HasDefaultValueSql("((2))");

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiasConfirmarReservar).HasDefaultValueSql("((1))");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnMantenimiento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('FF80FFFF')");

                entity.Property(e => e.Fax1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax2)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Logo).HasColumnType("image");

                entity.Property(e => e.NombreEmpresa)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumeroScript)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'11/06/2015')");

                entity.Property(e => e.PersonaJuridica)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReservaConfirmada)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('FFFF80FF')");

                entity.Property(e => e.ReservaEnCasa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('FF8080FF')");

                entity.Property(e => e.ReservaFacturada)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('FFFF8080')");

                entity.Property(e => e.ReservaTentativa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('FFFFFF80')");

                entity.Property(e => e.RutaLlamada)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono2)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Web)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFaCotizacion>(entity =>
            {
                entity.HasKey(e => e.IdCotizacion);

                entity.ToTable("Tb_FA_Cotizacion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaCotizacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCliente).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdUsuarioCreador).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdVendedor).HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoIvabase)
                    .HasColumnName("MontoIVABase")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoIvadolar)
                    .HasColumnName("MontoIVADolar")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoIvaeuro)
                    .HasColumnName("MontoIVAEuro")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PorcDescuentoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoNetoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoNetoDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoNetoEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoNetoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoNetoDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoNetoEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoCambioDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoCambioEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDescuentoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDescuentoDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDescuentoEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalEuro).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbFaCotizacion)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Tb_FA_Cotizacion_tb_CR_Contacto");
            });

            modelBuilder.Entity<TbFaCotizacionConfig>(entity =>
            {
                entity.HasKey(e => e.IdCotizacionConfig);

                entity.ToTable("Tb_FA_CotizacionConfig");

                entity.Property(e => e.DiasVenceDefecto).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdClienteDefecto).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdMonedaDefecto).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TbFaCotizacionDetalle>(entity =>
            {
                entity.HasKey(e => e.IdCotizacionDetalle);

                entity.ToTable("Tb_FA_CotizacionDetalle");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdInventario).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdUsuarioCreador).HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoIvaBase).HasColumnName("MontoIVABase");

                entity.Property(e => e.MontoIvaDolar)
                    .HasColumnName("MontoIVADolar")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PorcDescuento).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoNetoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoNetoDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalExcentoNetoEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoNetoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoNetoDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubTotalGravadoNetoEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDescuentoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDescuentoDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDescuentoEuro).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDolar).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalEuro).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.TbFaCotizacionDetalle)
                    .HasForeignKey(d => d.IdCotizacion)
                    .HasConstraintName("FK_Tb_FA_CotizacionDetalle_tb_PR_Inventario");
            });

            modelBuilder.Entity<TbFaCaja>(entity =>
            {
                entity.HasKey(e => e.IdCaja);

                entity.ToTable("tb_FA_Caja");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TbFaCajaAperturaDenominacion>(entity =>
            {
                entity.HasKey(e => e.IdCajaApertura);

                entity.ToTable("tb_FA_CajaAperturaDenominacion");

                entity.Property(e => e.Cantidad).HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCaja).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdDenominacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((0))");

                entity.Property(e => e.Monto).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaAperturaDenominacion)
                    .HasForeignKey(d => d.IdCaja)
                    .HasConstraintName("FK_tb_FA_CajaAperturaDenominacion_tb_FA_Caja");

                entity.HasOne(d => d.IdDenominacionNavigation)
                    .WithMany(p => p.TbFaCajaAperturaDenominacion)
                    .HasForeignKey(d => d.IdDenominacion)
                    .HasConstraintName("FK_tb_FA_CajaAperturaDenominacion_tb_FA_Denominacion");
            });

            modelBuilder.Entity<TbFaCajaArqueo>(entity =>
            {
                entity.HasKey(e => e.IdCajaArqueo);

                entity.ToTable("tb_FA_CajaArqueo");

                entity.Property(e => e.BancoReal).HasDefaultValueSql("((0))");

                entity.Property(e => e.EfectivoReal).HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCaja).HasDefaultValueSql("((0))");


                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((0))");

                entity.Property(e => e.TarjetaReal).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaArqueo)
                    .HasForeignKey(d => d.IdCaja)
                    .HasConstraintName("FK_tb_FA_CajaArqueo_tb_FA_CajaArqueo");


            });

            modelBuilder.Entity<TbFaCajaArqueoDenominacion>(entity =>
            {
                entity.HasKey(e => e.IdCajaArqueoDenominacion);

                entity.ToTable("tb_FA_CajaArqueoDenominacion");

                entity.Property(e => e.Cantidad).HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCaja).HasDefaultValueSql("((0))");


                entity.Property(e => e.IdDenominacion).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((0))");

                entity.Property(e => e.Monto).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaArqueoDenominacion)
                    .HasForeignKey(d => d.IdCaja)
                    .HasConstraintName("FK_tb_FA_CajaArqueoDenominacion_tb_FA_Caja");


                entity.HasOne(d => d.IdDenominacionNavigation)
                    .WithMany(p => p.TbFaCajaArqueoDenominacion)
                    .HasForeignKey(d => d.IdDenominacion)
                    .HasConstraintName("FK_tb_FA_CajaArqueoDenominacion_tb_FA_Denominacion");
            });
            modelBuilder.Entity<TbFaTipoJustificante>(entity =>
            {
                entity.HasKey(e => e.IdTipoJustificante);

                entity.ToTable("tb_FA_TipoJustificante");

                entity.Property(e => e.Cxc)
                    .IsRequired()
                    .HasColumnName("CXC")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cxp)
                    .IsRequired()
                    .HasColumnName("CXP")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                 .IsRequired()
                 .HasMaxLength(100)
                 .IsUnicode(false);
            });
            modelBuilder.Entity<TbFaTipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento);

                entity.ToTable("tb_FA_TipoDocumento");

                entity.Property(e => e.Cxc).HasColumnName("CXC");

                entity.Property(e => e.EsDebito).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<TbFaCajaMovimientoCheque>(entity =>
            {
                entity.HasKey(e => e.IdCajaMovimientoCheque);

                entity.ToTable("tb_FA_CajaMovimientoCheque");

                entity.Property(e => e.Banco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Portador)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdCajaMovimientoNavigation)
                    .WithMany(p => p.TbFaCajaMovimientoCheque)
                    .HasForeignKey(d => d.IdCajaMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimientoCheque_tb_FA_CajaMovimiento");
            });

            modelBuilder.Entity<TbFaCajaMovimientoTarjeta>(entity =>
            {
                entity.HasKey(e => e.IdCajaMovimientoTarjeta);

                entity.ToTable("tb_FA_CajaMovimientoTarjeta");

                entity.Property(e => e.IdCajaMovimientoTarjeta).ValueGeneratedNever();

                entity.Property(e => e.Autorizacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Voucher)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCajaMovimientoNavigation)
                    .WithMany(p => p.TbFaCajaMovimientoTarjeta)
                    .HasForeignKey(d => d.IdCajaMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimientoTarjeta_tb_FA_CajaMovimiento");
            });
            modelBuilder.Entity<TbFaNota>(entity =>
            {
                entity.HasKey(e => e.IdNotaCredito)
                    .HasName("PK_tb_FA_NotaCredito");

                entity.ToTable("tb_FA_Nota");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.TbFaNota)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_Nota_tb_FA_TipoDocumento");
            });
            modelBuilder.Entity<TbFaMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento);

                entity.ToTable("tb_FA_Movimiento");

                entity.Property(e => e.Cxc).HasColumnName("CXC");

                entity.Property(e => e.Cxp).HasColumnName("CXP");

                entity.Property(e => e.DisponibleDolar).HasMaxLength(10);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaldoBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaldoDolar).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.TbFaMovimiento)
                    .HasForeignKey(d => d.IdContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_Movimiento_tb_CR_Contacto");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.TbFaMovimiento)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_Movimiento_tb_FA_TipoDocumento");
            });
            modelBuilder.Entity<TbFaMovimientoDetalle>(entity =>
            {
                entity.HasKey(e => e.IdMovimientoDetalle);

                entity.ToTable("tb_FA_MovimientoDetalle");

                entity.Property(e => e.CompraDolarTc).HasColumnName("CompraDolarTC");

                entity.Property(e => e.CompraEuroTc).HasColumnName("CompraEuroTC");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VentaDolarTc).HasColumnName("VentaDolarTC");

                entity.Property(e => e.VentaEuroTc).HasColumnName("VentaEuroTC");

                entity.HasOne(d => d.IdMovimientoDesdeNavigation)
                    .WithMany(p => p.TbFaMovimientoDetalleIdMovimientoDesdeNavigation)
                    .HasForeignKey(d => d.IdMovimientoDesde)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_MovimientoDetalle_tb_FA_Movimiento");

                entity.HasOne(d => d.IdMovimientoHastaNavigation)
                    .WithMany(p => p.TbFaMovimientoDetalleIdMovimientoHastaNavigation)
                    .HasForeignKey(d => d.IdMovimientoHasta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_MovimientoDetalle_tb_FA_Movimiento1");
            });
            modelBuilder.Entity<TbFaMovimientoJustificante>(entity =>
            {
                entity.HasKey(e => e.IdMovimientoJustificante);

                entity.ToTable("tb_FA_MovimientoJustificante");

                entity.Property(e => e.CompraDolarTc).HasColumnName("CompraDolarTC");

                entity.Property(e => e.CompraEuroTc).HasColumnName("CompraEuroTC");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.VentaDolatTc).HasColumnName("VentaDolatTC");

                entity.Property(e => e.VentaEuroTc).HasColumnName("VentaEuroTC");

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.TbFaMovimientoJustificante)
                    .HasForeignKey(d => d.IdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_MovimientoJustificante_tb_FA_Movimiento");

                entity.HasOne(d => d.IdTipoJustificanteNavigation)
                    .WithMany(p => p.TbFaMovimientoJustificante)
                    .HasForeignKey(d => d.IdTipoJustificante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_MovimientoJustificante_tb_FA_TipoJustificante");
            });
            modelBuilder.Entity<TbFaCajaMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdCajaMovimiento);

                entity.ToTable("tb_FA_CajaMovimiento");

                entity.Property(e => e.CompraDolarTc).HasColumnName("CompraDolarTC");

                entity.Property(e => e.CompraEuroTc).HasColumnName("CompraEuroTC");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.VentaDolarTc).HasColumnName("VentaDolarTC");

                entity.Property(e => e.VentaEuroTc).HasColumnName("VentaEuroTC");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaMovimiento)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimiento_tb_FA_Caja");

                entity.HasOne(d => d.IdCategoriaFlujoNavigation)
                    .WithMany(p => p.TbFaCajaMovimiento)
                    .HasForeignKey(d => d.IdCategoriaFlujo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimiento_tb_BA_FlujoCategoria");

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.TbFaCajaMovimiento)
                    .HasForeignKey(d => d.IdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FA_CajaMovimiento_tb_FA_Movimiento");
            });

            modelBuilder.Entity<TbFaCajaCierre>(entity =>
            {
                entity.HasKey(e => e.IdCajaCierre)
                    .HasName("PK_tb_FA_CajaCierre+");

                entity.ToTable("tb_FA_CajaCierre");

                entity.Property(e => e.BancoReal).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bancos).HasDefaultValueSql("((0))");

                entity.Property(e => e.Efectivo).HasDefaultValueSql("((0))");

                entity.Property(e => e.EfectivoReal).HasDefaultValueSql("((0))");

                entity.Property(e => e.Entradas).HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCaja).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((0))");

                entity.Property(e => e.Salidas).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tarjeta).HasDefaultValueSql("((0))");

                entity.Property(e => e.TarjetaReal).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.TbFaCajaCierre)
                    .HasForeignKey(d => d.IdCaja)
                    .HasConstraintName("FK_tb_FA_CajaCierre_tb_FA_Caja");
            });


            modelBuilder.Entity<TbSePuntoVenta>(entity =>
            {
                entity.HasKey(e => e.IdPuntoVenta);

                entity.ToTable("tb_SE_PuntoVenta");

                entity.Property(e => e.CedulaJuridica)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMonedaFacturaDefecto).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdMonedaPrecio).HasDefaultValueSql("((1))");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrefijoConcecutivoIndepediente)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Web)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdTipoPrecioDefectoNavigation)
                    .WithMany(p => p.TbSePuntoVenta)
                    .HasForeignKey(d => d.IdTipoPrecioDefecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SE_PuntoVenta_tb_PR_Precios");
            });

        }
    }

}