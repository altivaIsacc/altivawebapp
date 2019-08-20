using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AltivaWebApp.Models
{
    public partial class BE_EmpresaContext : DbContext
    {
        public BE_EmpresaContext()
        {
        }

        public BE_EmpresaContext(DbContextOptions<BE_EmpresaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbBaConciliacion> TbBaConciliacion { get; set; }
        public virtual DbSet<TbBaConciliacionDetalle> TbBaConciliacionDetalle { get; set; }
        public virtual DbSet<TbBaCuentasBancarias> TbBaCuentasBancarias { get; set; }
        public virtual DbSet<TbBaMovimientoBancarios> TbBaMovimientoBancarios { get; set; }
        public virtual DbSet<TbBaMovimientoBancariosDetalle> TbBaMovimientoBancariosDetalle { get; set; }
        public virtual DbSet<TbCeCanton> TbCeCanton { get; set; }
        public virtual DbSet<TbCeCodigosReferencia> TbCeCodigosReferencia { get; set; }
        public virtual DbSet<TbCeCofiguracion> TbCeCofiguracion { get; set; }
        public virtual DbSet<TbCeColaAprobacion> TbCeColaAprobacion { get; set; }
        public virtual DbSet<TbCeComprobantesEnviados> TbCeComprobantesEnviados { get; set; }
        public virtual DbSet<TbCeConsecutivoProvisionalHa> TbCeConsecutivoProvisionalHa { get; set; }
        public virtual DbSet<TbCeDistrito> TbCeDistrito { get; set; }
        public virtual DbSet<TbCeProvincias> TbCeProvincias { get; set; }
        public virtual DbSet<TbCeSucursal> TbCeSucursal { get; set; }
        public virtual DbSet<TbCeTipoIdentificacion> TbCeTipoIdentificacion { get; set; }
        public virtual DbSet<TbCeTiposDocElectronicos> TbCeTiposDocElectronicos { get; set; }
        public virtual DbSet<TbCoAsientoContable> TbCoAsientoContable { get; set; }
        public virtual DbSet<TbCoAsientoContableDetalle> TbCoAsientoContableDetalle { get; set; }
        public virtual DbSet<TbCoCentrosDeGastos> TbCoCentrosDeGastos { get; set; }
        public virtual DbSet<TbCoCierreMensual> TbCoCierreMensual { get; set; }
        public virtual DbSet<TbCoCierreMensualTotales> TbCoCierreMensualTotales { get; set; }
        public virtual DbSet<TbCoConfiguracion> TbCoConfiguracion { get; set; }
        public virtual DbSet<TbCoCuentaContable> TbCoCuentaContable { get; set; }
        public virtual DbSet<TbCoParamentrosDeRenta> TbCoParamentrosDeRenta { get; set; }
        public virtual DbSet<TbCoPeriodoFiscal> TbCoPeriodoFiscal { get; set; }
        public virtual DbSet<TbCoPeriodoTrabajo> TbCoPeriodoTrabajo { get; set; }
        public virtual DbSet<TbCoSetting> TbCoSetting { get; set; }
        public virtual DbSet<TbCoSettingTipo> TbCoSettingTipo { get; set; }
        public virtual DbSet<TbCoTipoCuenta> TbCoTipoCuenta { get; set; }
        public virtual DbSet<TbCoTiposDocumentos> TbCoTiposDocumentos { get; set; }
        public virtual DbSet<TbCoUtilidadRenta> TbCoUtilidadRenta { get; set; }
        public virtual DbSet<TbCpCategoriaGasto> TbCpCategoriaGasto { get; set; }
        public virtual DbSet<TbCpGastoDetallado> TbCpGastoDetallado { get; set; }
        public virtual DbSet<TbCpGastos> TbCpGastos { get; set; }
        public virtual DbSet<TbCpPago> TbCpPago { get; set; }
        public virtual DbSet<TbCpPagoDetallado> TbCpPagoDetallado { get; set; }
        public virtual DbSet<TbCrCamposPersonalizados> TbCrCamposPersonalizados { get; set; }
        public virtual DbSet<TbCrContacto> TbCrContacto { get; set; }
        public virtual DbSet<TbCrContactoRelacion> TbCrContactoRelacion { get; set; }
        public virtual DbSet<TbCrContactosCamposPersonalizados> TbCrContactosCamposPersonalizados { get; set; }
        public virtual DbSet<TbCrListaDesplegables> TbCrListaDesplegables { get; set; }
        public virtual DbSet<TbFaDescuentoProducto> TbFaDescuentoProducto { get; set; }
        public virtual DbSet<TbFaDescuentoUsuario> TbFaDescuentoUsuario { get; set; }
        public virtual DbSet<TbFaDescuentoUsuarioClave> TbFaDescuentoUsuarioClave { get; set; }
        public virtual DbSet<TbFaDescuentoUsuarioRango> TbFaDescuentoUsuarioRango { get; set; }
        public virtual DbSet<TbFaPromocionProducto> TbFaPromocionProducto { get; set; }
        public virtual DbSet<TbFaRebajaConfig> TbFaRebajaConfig { get; set; }
        public virtual DbSet<TbFdAjusteSaldoMenor> TbFdAjusteSaldoMenor { get; set; }
        public virtual DbSet<TbFdAperturaCaja> TbFdAperturaCaja { get; set; }
        public virtual DbSet<TbFdArchivosAdjuntos> TbFdArchivosAdjuntos { get; set; }
        public virtual DbSet<TbFdArqueoCaja> TbFdArqueoCaja { get; set; }
        public virtual DbSet<TbFdAuditoriaFormaPago> TbFdAuditoriaFormaPago { get; set; }
        public virtual DbSet<TbFdAuditoriaIngresos> TbFdAuditoriaIngresos { get; set; }
        public virtual DbSet<TbFdAuditoriaNocturna> TbFdAuditoriaNocturna { get; set; }
        public virtual DbSet<TbFdAuditoriaOcupacion> TbFdAuditoriaOcupacion { get; set; }
        public virtual DbSet<TbFdAuditoriaRooming> TbFdAuditoriaRooming { get; set; }
        public virtual DbSet<TbFdBitacora> TbFdBitacora { get; set; }
        public virtual DbSet<TbFdCaracteristicaHabitacion> TbFdCaracteristicaHabitacion { get; set; }
        public virtual DbSet<TbFdCaracteristicaHabitacionAsoc> TbFdCaracteristicaHabitacionAsoc { get; set; }
        public virtual DbSet<TbFdCargoAlaHabitacion> TbFdCargoAlaHabitacion { get; set; }
        public virtual DbSet<TbFdCierreCaja> TbFdCierreCaja { get; set; }
        public virtual DbSet<TbFdCliente> TbFdCliente { get; set; }
        public virtual DbSet<TbFdComisionSobreVentasDetalle> TbFdComisionSobreVentasDetalle { get; set; }
        public virtual DbSet<TbFdComisionesSobreVentaPagoDetalle> TbFdComisionesSobreVentaPagoDetalle { get; set; }
        public virtual DbSet<TbFdComisionionesSobreVentaPago> TbFdComisionionesSobreVentaPago { get; set; }
        public virtual DbSet<TbFdCondicionesDePago> TbFdCondicionesDePago { get; set; }
        public virtual DbSet<TbFdConfiguracionCorreo> TbFdConfiguracionCorreo { get; set; }
        public virtual DbSet<TbFdConfiguracionFiltros> TbFdConfiguracionFiltros { get; set; }
        public virtual DbSet<TbFdContrato> TbFdContrato { get; set; }
        public virtual DbSet<TbFdContratoDescuento> TbFdContratoDescuento { get; set; }
        public virtual DbSet<TbFdContratoHospedaje> TbFdContratoHospedaje { get; set; }
        public virtual DbSet<TbFdContratoServicio> TbFdContratoServicio { get; set; }
        public virtual DbSet<TbFdContratoServicioTemp> TbFdContratoServicioTemp { get; set; }
        public virtual DbSet<TbFdContratoTipoHabitacion> TbFdContratoTipoHabitacion { get; set; }
        public virtual DbSet<TbFdContratoTipoTarifa> TbFdContratoTipoTarifa { get; set; }
        public virtual DbSet<TbFdCuentaDetalleServicioTarifa> TbFdCuentaDetalleServicioTarifa { get; set; }
        public virtual DbSet<TbFdCuentaEnCasa> TbFdCuentaEnCasa { get; set; }
        public virtual DbSet<TbFdCuentaEnCasaDetalle> TbFdCuentaEnCasaDetalle { get; set; }
        public virtual DbSet<TbFdCuentaEnCasaDetalleFacturaAnulada> TbFdCuentaEnCasaDetalleFacturaAnulada { get; set; }
        public virtual DbSet<TbFdCuentaEnCasaPagoCliente> TbFdCuentaEnCasaPagoCliente { get; set; }
        public virtual DbSet<TbFdCuentaEnCasaPuntoDeVenta> TbFdCuentaEnCasaPuntoDeVenta { get; set; }
        public virtual DbSet<TbFdCuentasBancarias> TbFdCuentasBancarias { get; set; }
        public virtual DbSet<TbFdDesgloceReserva> TbFdDesgloceReserva { get; set; }
        public virtual DbSet<TbFdDesgloceReservaNotas> TbFdDesgloceReservaNotas { get; set; }
        public virtual DbSet<TbFdDocumentoAjusteSaldoMenor> TbFdDocumentoAjusteSaldoMenor { get; set; }
        public virtual DbSet<TbFdDocumentos> TbFdDocumentos { get; set; }
        public virtual DbSet<TbFdFactura> TbFdFactura { get; set; }
        public virtual DbSet<TbFdFacturaDetalle> TbFdFacturaDetalle { get; set; }
        public virtual DbSet<TbFdFacturacion> TbFdFacturacion { get; set; }
        public virtual DbSet<TbFdFacturacionDetalle> TbFdFacturacionDetalle { get; set; }
        public virtual DbSet<TbFdFormaPago> TbFdFormaPago { get; set; }
        public virtual DbSet<TbFdHabitacion> TbFdHabitacion { get; set; }
        public virtual DbSet<TbFdHabitacionAsignada> TbFdHabitacionAsignada { get; set; }
        public virtual DbSet<TbFdHabitacionAsignadaFactura> TbFdHabitacionAsignadaFactura { get; set; }
        public virtual DbSet<TbFdHabitacionNoShow> TbFdHabitacionNoShow { get; set; }
        public virtual DbSet<TbFdHistoricoCuentaPorPagar> TbFdHistoricoCuentaPorPagar { get; set; }
        public virtual DbSet<TbFdHistoricoCuentasPorCobrar> TbFdHistoricoCuentasPorCobrar { get; set; }
        public virtual DbSet<TbFdJustificacion> TbFdJustificacion { get; set; }
        public virtual DbSet<TbFdJustificante> TbFdJustificante { get; set; }
        public virtual DbSet<TbFdNotaCreditoNddetalle> TbFdNotaCreditoNddetalle { get; set; }
        public virtual DbSet<TbFdNotaDebitoNcdetalle> TbFdNotaDebitoNcdetalle { get; set; }
        public virtual DbSet<TbFdNotaDebitoPagoDetalle> TbFdNotaDebitoPagoDetalle { get; set; }
        public virtual DbSet<TbFdNotaDetalleFactura> TbFdNotaDetalleFactura { get; set; }
        public virtual DbSet<TbFdNotasCredito> TbFdNotasCredito { get; set; }
        public virtual DbSet<TbFdNotasDebito> TbFdNotasDebito { get; set; }
        public virtual DbSet<TbFdOrigenReserva> TbFdOrigenReserva { get; set; }
        public virtual DbSet<TbFdPagoCliente> TbFdPagoCliente { get; set; }
        public virtual DbSet<TbFdPagoComision> TbFdPagoComision { get; set; }
        public virtual DbSet<TbFdPagoDetalleFactura> TbFdPagoDetalleFactura { get; set; }
        public virtual DbSet<TbFdReservacion> TbFdReservacion { get; set; }
        public virtual DbSet<TbFdReservacionHospedaje> TbFdReservacionHospedaje { get; set; }
        public virtual DbSet<TbFdReservacionServicio> TbFdReservacionServicio { get; set; }
        public virtual DbSet<TbFdReservacionServicioTarifa> TbFdReservacionServicioTarifa { get; set; }
        public virtual DbSet<TbFdRespaldoHabitacionAsignada> TbFdRespaldoHabitacionAsignada { get; set; }
        public virtual DbSet<TbFdRespaldoHabitacionesAsignadasAllotment> TbFdRespaldoHabitacionesAsignadasAllotment { get; set; }
        public virtual DbSet<TbFdServicio> TbFdServicio { get; set; }
        public virtual DbSet<TbFdSubtareas> TbFdSubtareas { get; set; }
        public virtual DbSet<TbFdTarea> TbFdTarea { get; set; }
        public virtual DbSet<TbFdTareaEstado> TbFdTareaEstado { get; set; }
        public virtual DbSet<TbFdTareaTipo> TbFdTareaTipo { get; set; }
        public virtual DbSet<TbFdTemporada> TbFdTemporada { get; set; }
        public virtual DbSet<TbFdTemporadaGrupo> TbFdTemporadaGrupo { get; set; }
        public virtual DbSet<TbFdTemporadaRango> TbFdTemporadaRango { get; set; }
        public virtual DbSet<TbFdTipoCliente> TbFdTipoCliente { get; set; }
        public virtual DbSet<TbFdTipoHabitacion> TbFdTipoHabitacion { get; set; }
        public virtual DbSet<TbFdTipoProveedor> TbFdTipoProveedor { get; set; }
        public virtual DbSet<TbFdTipoServicio> TbFdTipoServicio { get; set; }
        public virtual DbSet<TbFdTipoTarifa> TbFdTipoTarifa { get; set; }
        public virtual DbSet<TbPrAjuste> TbPrAjuste { get; set; }
        public virtual DbSet<TbPrAjusteInventario> TbPrAjusteInventario { get; set; }
        public virtual DbSet<TbPrBodega> TbPrBodega { get; set; }
        public virtual DbSet<TbPrCompra> TbPrCompra { get; set; }
        public virtual DbSet<TbPrCompraDetalle> TbPrCompraDetalle { get; set; }
        public virtual DbSet<TbPrContacto> TbPrContacto { get; set; }
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
        public virtual DbSet<TbPrPreciosInventarios> TbPrPreciosInventarios { get; set; }
        public virtual DbSet<TbPrPreciosInventariosAutomaticos> TbPrPreciosInventariosAutomaticos { get; set; }
        public virtual DbSet<TbPrPreciosInventariosAutomaticosDetalle> TbPrPreciosInventariosAutomaticosDetalle { get; set; }
        public virtual DbSet<TbPrPreciosInventariosDetalle> TbPrPreciosInventariosDetalle { get; set; }
        public virtual DbSet<TbPrProveedor> TbPrProveedor { get; set; }
        public virtual DbSet<TbPrRequisicion> TbPrRequisicion { get; set; }
        public virtual DbSet<TbPrRequisicionDetalle> TbPrRequisicionDetalle { get; set; }
        public virtual DbSet<TbPrTipoProveedor> TbPrTipoProveedor { get; set; }
        public virtual DbSet<TbPrToma> TbPrToma { get; set; }
        public virtual DbSet<TbPrTomaDetalle> TbPrTomaDetalle { get; set; }
        public virtual DbSet<TbPrTraslado> TbPrTraslado { get; set; }
        public virtual DbSet<TbPrTrasladoInventario> TbPrTrasladoInventario { get; set; }
        public virtual DbSet<TbPrUnidadMedida> TbPrUnidadMedida { get; set; }
        public virtual DbSet<TbReCategoriaMenu> TbReCategoriaMenu { get; set; }
        public virtual DbSet<TbReComanda> TbReComanda { get; set; }
        public virtual DbSet<TbReComplemento> TbReComplemento { get; set; }
        public virtual DbSet<TbReComplementoCategoriaMenu> TbReComplementoCategoriaMenu { get; set; }
        public virtual DbSet<TbReControladorMenu> TbReControladorMenu { get; set; }
        public virtual DbSet<TbReCortesias> TbReCortesias { get; set; }
        public virtual DbSet<TbReCuenta> TbReCuenta { get; set; }
        public virtual DbSet<TbReDesbloqueoFiguraSalon> TbReDesbloqueoFiguraSalon { get; set; }
        public virtual DbSet<TbReDescarga> TbReDescarga { get; set; }
        public virtual DbSet<TbReDescargaDetalle> TbReDescargaDetalle { get; set; }
        public virtual DbSet<TbReFacturacionMesa> TbReFacturacionMesa { get; set; }
        public virtual DbSet<TbReFiguraSalon> TbReFiguraSalon { get; set; }
        public virtual DbSet<TbReLineaOrden> TbReLineaOrden { get; set; }
        public virtual DbSet<TbReOrden> TbReOrden { get; set; }
        public virtual DbSet<TbReProducto> TbReProducto { get; set; }
        public virtual DbSet<TbReReciboCortesia> TbReReciboCortesia { get; set; }
        public virtual DbSet<TbReReciboCortesiaDetalle> TbReReciboCortesiaDetalle { get; set; }
        public virtual DbSet<TbReSalon> TbReSalon { get; set; }
        public virtual DbSet<TbReSubLineaOrden> TbReSubLineaOrden { get; set; }
        public virtual DbSet<TbReUnionFiguraSalon> TbReUnionFiguraSalon { get; set; }
        public virtual DbSet<TbSeAuditoriaInterna> TbSeAuditoriaInterna { get; set; }
        public virtual DbSet<TbSeConfiguracion> TbSeConfiguracion { get; set; }
        public virtual DbSet<TbSePuntoVenta> TbSePuntoVenta { get; set; }

        // Unable to generate entity type for table 'dbo.tb_FD_CuentaEnCasaNotaCredito'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tb_FD_NotaCreditoAjusteSaldoMenor'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tb_FD_AmadeLlave'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tmp_tb_PR_Requisicion'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tb_RE_Pantalla'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tb_RE_PantallaCategoriaMenu'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tb_FD_FacturaAutomatica'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tb_FD_FacturaAutomaticaDetalle'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tb_FD_NotaDebitoAjusteSaldoMenor'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SERVIDOR-PC\\FDPRUEBAS;Database=BE_Empresa;User id=sa;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<TbBaConciliacion>(entity =>
            {
                entity.HasKey(e => e.IdConciliacion);

                entity.ToTable("tb_BA_Conciliacion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TbBaConciliacionDetalle>(entity =>
            {
                entity.HasKey(e => e.IdConciliacionDetalle);

                entity.ToTable("tb_BA_ConciliacionDetalle");
            });

            modelBuilder.Entity<TbBaCuentasBancarias>(entity =>
            {
                entity.ToTable("tb_BA_CuentasBancarias");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaApertura).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaSaldoInicial).HasColumnType("datetime");

                entity.Property(e => e.FechaUltimaModificacion).HasColumnType("datetime");

                entity.Property(e => e.SaldoInicial).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<TbBaMovimientoBancarios>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento);

                entity.ToTable("tb_BA_MovimientoBancarios");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.NumDocumento)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Tccdolar).HasColumnName("TCCDolar");

                entity.Property(e => e.Tcceuro).HasColumnName("TCCEuro");

                entity.Property(e => e.Tcvdolar).HasColumnName("TCVDolar");

                entity.Property(e => e.Tcveuro).HasColumnName("TCVEuro");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbBaMovimientoBancariosDetalle>(entity =>
            {
                entity.ToTable("tb_BA_MovimientoBancariosDetalle");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Tccdolar).HasColumnName("TCCDolar");

                entity.Property(e => e.Tcceuro).HasColumnName("TCCEuro");

                entity.Property(e => e.Tcvdolar).HasColumnName("TCVDolar");

                entity.Property(e => e.Tcveuro).HasColumnName("TCVEuro");
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

            modelBuilder.Entity<TbCoCierreMensual>(entity =>
            {
                entity.ToTable("tb_CO_CierreMensual");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCoCierreMensualTotales>(entity =>
            {
                entity.ToTable("tb_CO_CierreMensualTotales");
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

            modelBuilder.Entity<TbCoParamentrosDeRenta>(entity =>
            {
                entity.ToTable("tb_CO_ParamentrosDeRenta");

                entity.Property(e => e.Tpccd).HasColumnName("TPCCD");

                entity.Property(e => e.Tpcce).HasColumnName("TPCCE");

                entity.Property(e => e.Tpcvd).HasColumnName("TPCVD");

                entity.Property(e => e.Tpcve).HasColumnName("TPCVE");
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

            modelBuilder.Entity<TbCpGastoDetallado>(entity =>
            {
                entity.HasKey(e => e.IdGastoDetalle)
                    .HasName("PK_tb_PR_GastoDetallado");

                entity.ToTable("tb_CP_GastoDetallado");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGastoNavigation)
                    .WithMany(p => p.TbCpGastoDetallado)
                    .HasForeignKey(d => d.IdGasto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_GastoDetallado_tb_PR_Gastos");
            });

            modelBuilder.Entity<TbCpGastos>(entity =>
            {
                entity.HasKey(e => e.IdGasto)
                    .HasName("PK_tb_PR_Gastos");

                entity.ToTable("tb_CP_Gastos");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.NumFactura)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.TbCpGastos)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_Gastos_tb_PR_Proveedores");
            });

            modelBuilder.Entity<TbCpPago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK_tb_CP_PagoAProveedores");

                entity.ToTable("tb_CP_Pago");

                entity.Property(e => e.CuentaBanco).HasMaxLength(50);

                entity.Property(e => e.Documento).HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbCpPagoDetallado>(entity =>
            {
                entity.HasKey(e => e.IdPagoDetallado)
                    .HasName("PK_tb_CP_PagoAProveedoresDetallado");

                entity.ToTable("tb_CP_PagoDetallado");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.NumFactura)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(50);
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

            modelBuilder.Entity<TbFaDescuentoProducto>(entity =>
            {
                entity.HasKey(e => e.IdDescuentoProducto);

                entity.ToTable("Tb_FA_DescuentoProducto");

                entity.Property(e => e.Tipo1)
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

            modelBuilder.Entity<TbFdAjusteSaldoMenor>(entity =>
            {
                entity.ToTable("tb_FD_AjusteSaldoMenor");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCorte)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TbFdAperturaCaja>(entity =>
            {
                entity.ToTable("tb_FD_AperturaCaja");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.Notas)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFdArchivosAdjuntos>(entity =>
            {
                entity.ToTable("tb_FD_ArchivosAdjuntos");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.TbFdArchivosAdjuntos)
                    .HasForeignKey(d => d.IdReserva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ArchivosAdjuntos_tb_FD_Reservacion");
            });

            modelBuilder.Entity<TbFdArqueoCaja>(entity =>
            {
                entity.ToTable("tb_FD_ArqueoCaja");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notas)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdAperturaNavigation)
                    .WithMany(p => p.TbFdArqueoCaja)
                    .HasForeignKey(d => d.IdApertura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ArqueoCaja_tb_FD_AperturaCaja");
            });

            modelBuilder.Entity<TbFdAuditoriaFormaPago>(entity =>
            {
                entity.ToTable("tb_FD_AuditoriaFormaPago");

                entity.Property(e => e.Moneda)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.TbFdAuditoriaFormaPago)
                    .HasForeignKey(d => d.IdFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_AuditoriaFormaPago_tb_FD_FormaPago");

                entity.HasOne(d => d.IdPagoClienteNavigation)
                    .WithMany(p => p.TbFdAuditoriaFormaPago)
                    .HasForeignKey(d => d.IdPagoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_AuditoriaFormaPago_tb_FD_PagoCliente");
            });

            modelBuilder.Entity<TbFdAuditoriaIngresos>(entity =>
            {
                entity.ToTable("tb_FD_AuditoriaIngresos");

                entity.Property(e => e.Cliente)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dia)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Habitacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Moneda)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbFdAuditoriaIngresos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_AuditoriaIngresos_tb_FD_Cliente1");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.TbFdAuditoriaIngresos)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_AuditoriaIngresos_tb_FD_Servicio1");

                entity.HasOne(d => d.IdTipoServicioNavigation)
                    .WithMany(p => p.TbFdAuditoriaIngresos)
                    .HasForeignKey(d => d.IdTipoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_AuditoriaIngresos_tb_FD_TipoServicio1");
            });

            modelBuilder.Entity<TbFdAuditoriaNocturna>(entity =>
            {
                entity.ToTable("tb_FD_AuditoriaNocturna");

                entity.Property(e => e.Creacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dia).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFdAuditoriaOcupacion>(entity =>
            {
                entity.ToTable("tb_FD_AuditoriaOcupacion");

                entity.Property(e => e.Dia)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipoHabitacion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdTipoHabitacionNavigation)
                    .WithMany(p => p.TbFdAuditoriaOcupacion)
                    .HasForeignKey(d => d.IdTipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_AuditoriaOcupacion_tb_FD_TipoHabitacion1");
            });

            modelBuilder.Entity<TbFdAuditoriaRooming>(entity =>
            {
                entity.ToTable("tb_FD_AuditoriaRooming");

                entity.Property(e => e.FechaEntrada)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Huesped)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoHabitacion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbFdAuditoriaRooming)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_AuditoriaRooming_tb_FD_Cliente1");

                entity.HasOne(d => d.IdTipoHabitacionNavigation)
                    .WithMany(p => p.TbFdAuditoriaRooming)
                    .HasForeignKey(d => d.IdTipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_AuditoriaRooming_tb_FD_TipoHabitacion1");
            });

            modelBuilder.Entity<TbFdBitacora>(entity =>
            {
                entity.ToTable("tb_FD_Bitacora");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1)/(1))/(2015))");

                entity.Property(e => e.TipoReferencia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbFdCaracteristicaHabitacion>(entity =>
            {
                entity.ToTable("tb_FD_CaracteristicaHabitacion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFdCaracteristicaHabitacionAsoc>(entity =>
            {
                entity.ToTable("tb_FD_CaracteristicaHabitacionAsoc");

                entity.HasOne(d => d.IdCaracteristicaNavigation)
                    .WithMany(p => p.TbFdCaracteristicaHabitacionAsoc)
                    .HasForeignKey(d => d.IdCaracteristica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CaracteristicaHabitacionAsoc_tb_FD_CaracteristicaHabitacion");

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.TbFdCaracteristicaHabitacionAsoc)
                    .HasForeignKey(d => d.IdHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CaracteristicaHabitacionAsoc_tb_FD_Habitacion1");
            });

            modelBuilder.Entity<TbFdCargoAlaHabitacion>(entity =>
            {
                entity.ToTable("tb_FD_CargoAlaHabitacion");
            });

            modelBuilder.Entity<TbFdCierreCaja>(entity =>
            {
                entity.ToTable("tb_FD_CierreCaja");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdAperturaNavigation)
                    .WithMany(p => p.TbFdCierreCaja)
                    .HasForeignKey(d => d.IdApertura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CierreCaja_tb_FD_AperturaCaja");

                entity.HasOne(d => d.IdArqueoNavigation)
                    .WithMany(p => p.TbFdCierreCaja)
                    .HasForeignKey(d => d.IdArqueo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CierreCaja_tb_FD_ArqueoCaja");
            });

            modelBuilder.Entity<TbFdCliente>(entity =>
            {
                entity.ToTable("tb_FD_Cliente");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contacto)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DigitosTarjetaGarantia)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Direccion1)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Direccion2)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email3)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailContacto)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreJuridico)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumTarjetaGarantia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OtroContacto)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciaCrediticia)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telefono3)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TelefonoContacto)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoId)
                    .IsRequired()
                    .HasColumnName("TipoID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('NO TRIBUTARIO')");

                entity.Property(e => e.TipoReferencia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VenceTarjetaGarantia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WebSite1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WebSite2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.TbFdCliente)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Cliente_tb_FD_Contrato1");
            });

            modelBuilder.Entity<TbFdComisionSobreVentasDetalle>(entity =>
            {
                entity.ToTable("tb_FD_ComisionSobreVentasDetalle");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFdComisionesSobreVentaPagoDetalle>(entity =>
            {
                entity.ToTable("tb_FD_ComisionesSobreVentaPagoDetalle");

                entity.Property(e => e.Tpcd).HasColumnName("TPCD");

                entity.Property(e => e.Tpce).HasColumnName("TPCE");
            });

            modelBuilder.Entity<TbFdComisionionesSobreVentaPago>(entity =>
            {
                entity.ToTable("tb_FD_ComisionionesSobreVentaPago");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((2)-(2))-(2000))");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.IdCuentaBancaria)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ReciboManual)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tcambio).HasColumnName("TCambio");

                entity.Property(e => e.Tcdolar).HasColumnName("TCDolar");

                entity.Property(e => e.Tceuro).HasColumnName("TCEuro");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
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

            modelBuilder.Entity<TbFdConfiguracionCorreo>(entity =>
            {
                entity.ToTable("tb_FD_ConfiguracionCorreo");

                entity.Property(e => e.AlertasCopiarA)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.AlertasEnviar)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.AsuntoTarjetaConfirmar)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AuditoriaCopiarA)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.AuditoriaEnviar)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.DespedidaTarjetaConfirmar)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.InformeCopiarA)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.InformeEnviar)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.SaludoTarjetaConfirmar)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.ServidorSalida)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.TarjetaConfirmarCopiarA)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");
            });

            modelBuilder.Entity<TbFdConfiguracionFiltros>(entity =>
            {
                entity.ToTable("tb_FD_ConfiguracionFiltros");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TbFdContrato>(entity =>
            {
                entity.ToTable("tb_FD_Contrato");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFdContratoDescuento>(entity =>
            {
                entity.ToTable("tb_FD_ContratoDescuento");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.TbFdContratoDescuento)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoDescuento_tb_FD_Contrato");
            });

            modelBuilder.Entity<TbFdContratoHospedaje>(entity =>
            {
                entity.ToTable("tb_FD_ContratoHospedaje");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cuadruple).HasColumnName("CUADRUPLE");

                entity.Property(e => e.Doble).HasColumnName("DOBLE");

                entity.Property(e => e.Sencilla).HasColumnName("SENCILLA");

                entity.Property(e => e.Triple).HasColumnName("TRIPLE");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.TbFdContratoHospedaje)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoHospedaje_tb_FD_Contrato");
            });

            modelBuilder.Entity<TbFdContratoServicio>(entity =>
            {
                entity.ToTable("tb_FD_ContratoServicio");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.TbFdContratoServicio)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoServicio_tb_FD_Contrato");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.TbFdContratoServicio)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoServicio_tb_FD_Servicio");

                entity.HasOne(d => d.IdTemporadaNavigation)
                    .WithMany(p => p.TbFdContratoServicio)
                    .HasForeignKey(d => d.IdTemporada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoServicio_tb_FD_Temporada");

                entity.HasOne(d => d.IdTipoTarifaNavigation)
                    .WithMany(p => p.TbFdContratoServicio)
                    .HasForeignKey(d => d.IdTipoTarifa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoServicio_tb_FD_TipoTarifa");
            });

            modelBuilder.Entity<TbFdContratoServicioTemp>(entity =>
            {
                entity.ToTable("tb_FD_ContratoServicioTemp");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.TbFdContratoServicioTemp)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoServicioTemp_tb_FD_Contrato");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.TbFdContratoServicioTemp)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoServicioTemp_tb_FD_Servicio");
            });

            modelBuilder.Entity<TbFdContratoTipoHabitacion>(entity =>
            {
                entity.ToTable("tb_FD_ContratoTipoHabitacion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.TbFdContratoTipoHabitacion)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoTipoHabitacion_tb_FD_Contrato");

                entity.HasOne(d => d.IdTipoHabitacionNavigation)
                    .WithMany(p => p.TbFdContratoTipoHabitacion)
                    .HasForeignKey(d => d.IdTipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoTipoHabitacion_tb_FD_TipoHabitacion");
            });

            modelBuilder.Entity<TbFdContratoTipoTarifa>(entity =>
            {
                entity.ToTable("tb_FD_ContratoTipoTarifa");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.IdContratoNavigation)
                    .WithMany(p => p.TbFdContratoTipoTarifa)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoTipoTarifa_tb_FD_Contrato");

                entity.HasOne(d => d.IdTipoTarifaNavigation)
                    .WithMany(p => p.TbFdContratoTipoTarifa)
                    .HasForeignKey(d => d.IdTipoTarifa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ContratoTipoTarifa_tb_FD_TipoTarifa");
            });

            modelBuilder.Entity<TbFdCuentaDetalleServicioTarifa>(entity =>
            {
                entity.ToTable("tb_FD_CuentaDetalleServicioTarifa");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdCuentaEnCasaNavigation)
                    .WithMany(p => p.TbFdCuentaDetalleServicioTarifa)
                    .HasForeignKey(d => d.IdCuentaEnCasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaDetalleServicioTarifa_tb_FD_CuentaEnCasa");

                entity.HasOne(d => d.IdCuentaEnCasaDetalleNavigation)
                    .WithMany(p => p.TbFdCuentaDetalleServicioTarifa)
                    .HasForeignKey(d => d.IdCuentaEnCasaDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaDetalleServicioTarifa_tb_FD_CuentaEnCasaDetalle");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.TbFdCuentaDetalleServicioTarifa)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaDetalleServicioTarifa_tb_FD_Servicio");
            });

            modelBuilder.Entity<TbFdCuentaEnCasa>(entity =>
            {
                entity.ToTable("tb_FD_CuentaEnCasa");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HoraEntrada)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HoraSalida)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbFdCuentaEnCasa)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaEnCasa_tb_FD_Cliente");

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.TbFdCuentaEnCasa)
                    .HasForeignKey(d => d.IdHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaEnCasa_tb_FD_Habitacion1");

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.TbFdCuentaEnCasa)
                    .HasForeignKey(d => d.IdReserva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaEnCasa_tb_FD_Reservacion");
            });

            modelBuilder.Entity<TbFdCuentaEnCasaDetalle>(entity =>
            {
                entity.ToTable("tb_FD_CuentaEnCasaDetalle");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fdesde)
                    .HasColumnName("FDesde")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaInsersion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fhasta)
                    .HasColumnName("FHasta")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tpcd).HasColumnName("TPCD");

                entity.Property(e => e.Tpce).HasColumnName("TPCE");

                entity.HasOne(d => d.IdCuentaEnCasaNavigation)
                    .WithMany(p => p.TbFdCuentaEnCasaDetalle)
                    .HasForeignKey(d => d.IdCuentaEnCasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaEnCasaDetalle_tb_FD_CuentaEnCasa");
            });

            modelBuilder.Entity<TbFdCuentaEnCasaDetalleFacturaAnulada>(entity =>
            {
                entity.ToTable("tb_FD_CuentaEnCasaDetalleFacturaAnulada");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fdesde)
                    .HasColumnName("FDesde")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fhasta)
                    .HasColumnName("FHasta")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbFdCuentaEnCasaPagoCliente>(entity =>
            {
                entity.ToTable("tb_FD_CuentaEnCasaPagoCliente");

                entity.HasOne(d => d.IdCuentaEnCasaNavigation)
                    .WithMany(p => p.TbFdCuentaEnCasaPagoCliente)
                    .HasForeignKey(d => d.IdCuentaEnCasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaEnCasaPagoCliente_tb_FD_CuentaEnCasa");

                entity.HasOne(d => d.IdPagoClienteNavigation)
                    .WithMany(p => p.TbFdCuentaEnCasaPagoCliente)
                    .HasForeignKey(d => d.IdPagoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaEnCasaPagoCliente_tb_FD_PagoCliente");
            });

            modelBuilder.Entity<TbFdCuentaEnCasaPuntoDeVenta>(entity =>
            {
                entity.ToTable("tb_FD_CuentaEnCasaPuntoDeVenta");

                entity.HasOne(d => d.IdCuentaEnCasaNavigation)
                    .WithMany(p => p.TbFdCuentaEnCasaPuntoDeVenta)
                    .HasForeignKey(d => d.IdCuentaEnCasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaEnCasaPuntoDeVenta_tb_FD_CuentaEnCasa");

                entity.HasOne(d => d.IdPuntoVentaNavigation)
                    .WithMany(p => p.TbFdCuentaEnCasaPuntoDeVenta)
                    .HasForeignKey(d => d.IdPuntoVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_CuentaEnCasaPuntoDeVenta_tb_SE_PuntoVenta");
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

            modelBuilder.Entity<TbFdDesgloceReserva>(entity =>
            {
                entity.ToTable("tb_FD_DesgloceReserva");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaRelacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdPagoClienteNavigation)
                    .WithMany(p => p.TbFdDesgloceReserva)
                    .HasForeignKey(d => d.IdPagoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_DesgloceReserva_tb_FD_PagoCliente");
            });

            modelBuilder.Entity<TbFdDesgloceReservaNotas>(entity =>
            {
                entity.ToTable("tb_FD_DesgloceReservaNotas");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaRelacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdNotaCreditoNavigation)
                    .WithMany(p => p.TbFdDesgloceReservaNotas)
                    .HasForeignKey(d => d.IdNotaCredito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_DesgloceReservaNotas_tb_FD_NotasCredito1");

                entity.HasOne(d => d.IdReservacionNavigation)
                    .WithMany(p => p.TbFdDesgloceReservaNotas)
                    .HasForeignKey(d => d.IdReservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_DesgloceReservaNotas_tb_FD_Reservacion1");
            });

            modelBuilder.Entity<TbFdDocumentoAjusteSaldoMenor>(entity =>
            {
                entity.ToTable("tb_FD_DocumentoAjusteSaldoMenor");

                entity.Property(e => e.Cliente)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDocumento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdAjusteSaldoMenorNavigation)
                    .WithMany(p => p.TbFdDocumentoAjusteSaldoMenor)
                    .HasForeignKey(d => d.IdAjusteSaldoMenor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_DocumentoAjusteSaldoMenor_tb_FD_AjusteSaldoMenor");

                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.TbFdDocumentoAjusteSaldoMenor)
                    .HasForeignKey(d => d.IdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_DocumentoAjusteSaldoMenor_tb_FD_Facturacion");

                entity.HasOne(d => d.IdDocumento1)
                    .WithMany(p => p.TbFdDocumentoAjusteSaldoMenor)
                    .HasForeignKey(d => d.IdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_DocumentoAjusteSaldoMenor_tb_FD_NotasDebito");
            });

            modelBuilder.Entity<TbFdDocumentos>(entity =>
            {
                entity.ToTable("tb_FD_Documentos");

                entity.Property(e => e.DireccionArchivo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdReservaNavigation)
                    .WithMany(p => p.TbFdDocumentos)
                    .HasForeignKey(d => d.IdReserva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Documentos_tb_FD_Reservacion");
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

            modelBuilder.Entity<TbFdFacturacion>(entity =>
            {
                entity.ToTable("tb_FD_Facturacion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaEntrada)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1)/(1))/(2000))");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((1012000))");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((2))");

                entity.Property(e => e.IdPuntoVenta).HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbFdFacturacion)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Facturacion_tb_FD_Cliente");

                entity.HasOne(d => d.IdCuentaEnCasaNavigation)
                    .WithMany(p => p.TbFdFacturacion)
                    .HasForeignKey(d => d.IdCuentaEnCasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Facturacion_tb_FD_CuentaEnCasa");
            });

            modelBuilder.Entity<TbFdFacturacionDetalle>(entity =>
            {
                entity.ToTable("tb_FD_FacturacionDetalle");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fdesde)
                    .HasColumnName("FDesde")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fhasta)
                    .HasColumnName("FHasta")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.TbFdFacturacionDetalle)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_FacturacionDetalle_tb_FD_Facturacion");
            });

            modelBuilder.Entity<TbFdFormaPago>(entity =>
            {
                entity.ToTable("tb_FD_FormaPago");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCuentaBancaria)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdAperturaCajaNavigation)
                    .WithMany(p => p.TbFdFormaPago)
                    .HasForeignKey(d => d.IdAperturaCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_FormaPago_tb_FD_AperturaCaja");

                entity.HasOne(d => d.IdPagoClienteNavigation)
                    .WithMany(p => p.TbFdFormaPago)
                    .HasForeignKey(d => d.IdPagoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_FormaPago_tb_FD_PagoCliente");
            });

            modelBuilder.Entity<TbFdHabitacion>(entity =>
            {
                entity.ToTable("tb_FD_Habitacion");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ocupacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('DOBLE')");

                entity.HasOne(d => d.TipoHabitacionNavigation)
                    .WithMany(p => p.TbFdHabitacion)
                    .HasForeignKey(d => d.TipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Habitacion_tb_FD_TipoHabitacion");
            });

            modelBuilder.Entity<TbFdHabitacionAsignada>(entity =>
            {
                entity.ToTable("tb_FD_HabitacionAsignada");

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFdHabitacionAsignadaFactura>(entity =>
            {
                entity.ToTable("tb_FD_HabitacionAsignadaFactura");

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFdHabitacionNoShow>(entity =>
            {
                entity.ToTable("tb_FD_HabitacionNoShow");

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFdHistoricoCuentaPorPagar>(entity =>
            {
                entity.ToTable("tb_FD_HistoricoCuentaPorPagar");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.IdDocumentoCxc).HasColumnName("IdDocumentoCXC");

                entity.Property(e => e.IdDocumentoCxp).HasColumnName("IdDocumentoCXP");

                entity.Property(e => e.MontoAplicado).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TipoDocuementoCxp)
                    .IsRequired()
                    .HasColumnName("TipoDocuementoCXP")
                    .HasMaxLength(50);

                entity.Property(e => e.TipoDocumentoCxc)
                    .IsRequired()
                    .HasColumnName("TipoDocumentoCXC")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbFdHistoricoCuentasPorCobrar>(entity =>
            {
                entity.ToTable("tb_FD_HistoricoCuentasPorCobrar");

                entity.Property(e => e.Aplicado).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((2)-(2))-(2002))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((2)-(2))-(2000))");

                entity.Property(e => e.Monto).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Pendiente).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFdJustificacion>(entity =>
            {
                entity.ToTable("tb_FD_Justificacion");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Justificacion)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Movimiento)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TipoReferencia)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbFdJustificante>(entity =>
            {
                entity.ToTable("tb_FD_Justificante");

                entity.Property(e => e.Conversion).HasDefaultValueSql("((0))");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAperturaCaja).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoNota)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdAperturaCajaNavigation)
                    .WithMany(p => p.TbFdJustificante)
                    .HasForeignKey(d => d.IdAperturaCaja)
                    .HasConstraintName("FK_tb_FD_Justificante_tb_FD_AperturaCaja1");

                entity.HasOne(d => d.IdNotaNavigation)
                    .WithMany(p => p.TbFdJustificante)
                    .HasForeignKey(d => d.IdNota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Justificante_tb_FD_NotasCredito1");

                entity.HasOne(d => d.IdNota1)
                    .WithMany(p => p.TbFdJustificante)
                    .HasForeignKey(d => d.IdNota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Justificante_tb_FD_NotasDebito");
            });

            modelBuilder.Entity<TbFdNotaCreditoNddetalle>(entity =>
            {
                entity.ToTable("tb_FD_NotaCreditoNDDetalle");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFdNotaDebitoNcdetalle>(entity =>
            {
                entity.ToTable("tb_FD_NotaDebitoNCDetalle");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNotaCreditoNavigation)
                    .WithMany(p => p.TbFdNotaDebitoNcdetalle)
                    .HasForeignKey(d => d.IdNotaCredito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_NotaDebitoNCDetalle_tb_FD_NotasCredito1");

                entity.HasOne(d => d.IdNotaDebitoNavigation)
                    .WithMany(p => p.TbFdNotaDebitoNcdetalle)
                    .HasForeignKey(d => d.IdNotaDebito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_NotaDebitoNCDetalle_tb_FD_NotasDebito1");
            });

            modelBuilder.Entity<TbFdNotaDebitoPagoDetalle>(entity =>
            {
                entity.ToTable("tb_FD_NotaDebitoPagoDetalle");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNotaDebitoNavigation)
                    .WithMany(p => p.TbFdNotaDebitoPagoDetalle)
                    .HasForeignKey(d => d.IdNotaDebito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_NotaDebitoPagoDetalle_tb_FD_NotasDebito");

                entity.HasOne(d => d.IdPagClienteNavigation)
                    .WithMany(p => p.TbFdNotaDebitoPagoDetalle)
                    .HasForeignKey(d => d.IdPagCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_NotaDebitoPagoDetalle_tb_FD_PagoCliente");
            });

            modelBuilder.Entity<TbFdNotaDetalleFactura>(entity =>
            {
                entity.ToTable("tb_FD_NotaDetalleFactura");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.TbFdNotaDetalleFactura)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_NotaDetalleFactura_tb_FD_Facturacion");

                entity.HasOne(d => d.IdNotaCreditoNavigation)
                    .WithMany(p => p.TbFdNotaDetalleFactura)
                    .HasForeignKey(d => d.IdNotaCredito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_NotaDetalleFactura_tb_FD_NotasCredito1");
            });

            modelBuilder.Entity<TbFdNotasCredito>(entity =>
            {
                entity.ToTable("tb_FD_NotasCredito");

                entity.Property(e => e.EsAjusteSaldoMenor)
                    .IsRequired()
                    .HasDefaultValueSql("('False')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.TipoNota)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'NC')");
            });

            modelBuilder.Entity<TbFdNotasDebito>(entity =>
            {
                entity.ToTable("tb_FD_NotasDebito");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TipoNota)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFdOrigenReserva>(entity =>
            {
                entity.ToTable("tb_FD_OrigenReserva");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFdPagoCliente>(entity =>
            {
                entity.ToTable("tb_FD_PagoCliente");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaPago)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReciboManual)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbFdPagoCliente)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_PagoCliente_tb_FD_Cliente");
            });

            modelBuilder.Entity<TbFdPagoComision>(entity =>
            {
                entity.ToTable("tb_FD_PagoComision");

                entity.Property(e => e.FechaPagoCom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbFdPagoComision)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_PagoComision_tb_FD_Cliente");
            });

            modelBuilder.Entity<TbFdPagoDetalleFactura>(entity =>
            {
                entity.ToTable("tb_FD_PagoDetalleFactura");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdPagoClienteNavigation)
                    .WithMany(p => p.TbFdPagoDetalleFactura)
                    .HasForeignKey(d => d.IdPagoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_PagoDetalleFactura_tb_FD_PagoCliente");
            });

            modelBuilder.Entity<TbFdReservacion>(entity =>
            {
                entity.ToTable("tb_FD_Reservacion");

                entity.Property(e => e.EnMantenimiento)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EsAllotment)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('TENTATIVA')");

                entity.Property(e => e.FechaInclusion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HoraEntrada)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HoraSalida)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nota)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotaInterna)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdClienteFacturaNavigation)
                    .WithMany(p => p.TbFdReservacion)
                    .HasForeignKey(d => d.IdClienteFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Reservacion_tb_FD_Cliente1");

                entity.HasOne(d => d.IdOrigenReservaNavigation)
                    .WithMany(p => p.TbFdReservacion)
                    .HasForeignKey(d => d.IdOrigenReserva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Reservacion_tb_FD_OrigenReserva");

                entity.HasOne(d => d.IdPagoComisionNavigation)
                    .WithMany(p => p.TbFdReservacion)
                    .HasForeignKey(d => d.IdPagoComision)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Reservacion_tb_FD_PagoComision");
            });

            modelBuilder.Entity<TbFdReservacionHospedaje>(entity =>
            {
                entity.ToTable("tb_FD_ReservacionHospedaje");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fentrada)
                    .HasColumnName("FEntrada")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fsalida)
                    .HasColumnName("FSalida")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ocupacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdReservacionNavigation)
                    .WithMany(p => p.TbFdReservacionHospedaje)
                    .HasForeignKey(d => d.IdReservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ReservacionHospedaje_tb_FD_Reservacion1");

                entity.HasOne(d => d.IdTipoHabitacionNavigation)
                    .WithMany(p => p.TbFdReservacionHospedaje)
                    .HasForeignKey(d => d.IdTipoHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ReservacionHospedaje_tb_FD_TipoHabitacion1");

                entity.HasOne(d => d.IdTipoTarifaNavigation)
                    .WithMany(p => p.TbFdReservacionHospedaje)
                    .HasForeignKey(d => d.IdTipoTarifa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ReservacionHospedaje_tb_FD_TipoTarifa1");
            });

            modelBuilder.Entity<TbFdReservacionServicio>(entity =>
            {
                entity.ToTable("tb_FD_ReservacionServicio");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaDesde)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaHasta)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdReservacionNavigation)
                    .WithMany(p => p.TbFdReservacionServicio)
                    .HasForeignKey(d => d.IdReservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ReservacionServicio_tb_FD_Reservacion");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.TbFdReservacionServicio)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ReservacionServicio_tb_FD_Servicio");

                entity.HasOne(d => d.IdTipoTarifaNavigation)
                    .WithMany(p => p.TbFdReservacionServicio)
                    .HasForeignKey(d => d.IdTipoTarifa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_ReservacionServicio_tb_FD_TipoTarifa");
            });

            modelBuilder.Entity<TbFdReservacionServicioTarifa>(entity =>
            {
                entity.ToTable("tb_FD_ReservacionServicioTarifa");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TbFdRespaldoHabitacionAsignada>(entity =>
            {
                entity.ToTable("tb_FD_RespaldoHabitacionAsignada");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbFdRespaldoHabitacionesAsignadasAllotment>(entity =>
            {
                entity.ToTable("tb_FD_RespaldoHabitacionesAsignadasAllotment");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TbFdServicio>(entity =>
            {
                entity.ToTable("tb_FD_Servicio");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
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

            modelBuilder.Entity<TbFdTemporada>(entity =>
            {
                entity.ToTable("tb_FD_Temporada");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdGrupoTemporadasNavigation)
                    .WithMany(p => p.TbFdTemporada)
                    .HasForeignKey(d => d.IdGrupoTemporadas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_Temporada_tb_FD_TemporadaGrupo");
            });

            modelBuilder.Entity<TbFdTemporadaGrupo>(entity =>
            {
                entity.ToTable("tb_FD_TemporadaGrupo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFdTemporadaRango>(entity =>
            {
                entity.ToTable("tb_FD_TemporadaRango");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.IdTemporadaNavigation)
                    .WithMany(p => p.TbFdTemporadaRango)
                    .HasForeignKey(d => d.IdTemporada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_FD_TemporadaRango_tb_FD_Temporada");
            });

            modelBuilder.Entity<TbFdTipoCliente>(entity =>
            {
                entity.ToTable("TB_FD_TipoCliente");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbFdTipoHabitacion>(entity =>
            {
                entity.ToTable("tb_FD_TipoHabitacion");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('FFC0C0C0')");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdCuentaContable)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreCuenta)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SobreVentas)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TbFdTipoProveedor>(entity =>
            {
                entity.ToTable("TB_FD_TipoProveedor");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbFdTipoServicio>(entity =>
            {
                entity.ToTable("tb_FD_TipoServicio");

                entity.Property(e => e.IdCuentaContable)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreCuenta)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbFdTipoTarifa>(entity =>
            {
                entity.ToTable("tb_FD_TipoTarifa");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
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

            modelBuilder.Entity<TbPrContacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto);

                entity.ToTable("tb_PR_Contacto");

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");
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
                    .HasDefaultValueSql("('''')");

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
                    .HasMaxLength(50);

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

            modelBuilder.Entity<TbPrProveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK_tb_PR_Proveedores");

                entity.ToTable("tb_PR_Proveedor");

                entity.Property(e => e.CodigoMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Email1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Email2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.PersoneriaJuridica)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.SitioWeb)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Telefono2)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");
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

            modelBuilder.Entity<TbPrTraslado>(entity =>
            {
                entity.HasKey(e => e.IdTraslado)
                    .HasName("PK_tb_PR_Traslados");

                entity.ToTable("tb_PR_Traslado");

                entity.Property(e => e.Anulado)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TbPrTrasladoInventario>(entity =>
            {
                entity.ToTable("tb_PR_TrasladoInventario");

                entity.Property(e => e.CodigoArticulo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
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

            modelBuilder.Entity<TbReCategoriaMenu>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaMenu);

                entity.ToTable("tb_RE_CategoriaMenu");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Imagen).HasColumnType("image");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbReComanda>(entity =>
            {
                entity.HasKey(e => e.IdComanda);

                entity.ToTable("tb_RE_Comanda");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('TOGO')");
            });

            modelBuilder.Entity<TbReComplemento>(entity =>
            {
                entity.HasKey(e => e.IdComplemento);

                entity.ToTable("tb_RE_Complemento");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Imagen).HasColumnType("image");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TieneIs).HasColumnName("TieneIS");

                entity.Property(e => e.TieneIv).HasColumnName("TieneIV");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('MOD')");
            });

            modelBuilder.Entity<TbReComplementoCategoriaMenu>(entity =>
            {
                entity.HasKey(e => e.IdComplementoCategoriaMenu);

                entity.ToTable("tb_RE_ComplementoCategoriaMenu");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.TbReComplementoCategoriaMenu)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_RE_ComplementoCategoriaMenu_tb_RE_CategoriaMenu");

                entity.HasOne(d => d.IdComplementoNavigation)
                    .WithMany(p => p.TbReComplementoCategoriaMenu)
                    .HasForeignKey(d => d.IdComplemento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_RE_ComplementoCategoriaMenu_tb_RE_Complemento");
            });

            modelBuilder.Entity<TbReControladorMenu>(entity =>
            {
                entity.HasKey(e => e.IdControladorMenu)
                    .HasName("PK_tb_RE_ConfiguracionMenu");

                entity.ToTable("tb_RE_ControladorMenu");

                entity.Property(e => e.TipoItems)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbReCortesias>(entity =>
            {
                entity.HasKey(e => e.IdCortesias);

                entity.ToTable("tb_RE_Cortesias");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbReCuenta>(entity =>
            {
                entity.HasKey(e => e.IdCuenta);

                entity.ToTable("tb_RE_Cuenta");

                entity.Property(e => e.ExoneradoIs).HasColumnName("ExoneradoIS");

                entity.Property(e => e.ExoneradoIv).HasColumnName("ExoneradoIV");

                entity.Property(e => e.FechaApertura).HasColumnType("datetime");

                entity.Property(e => e.NombreCuenta)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdComandaNavigation)
                    .WithMany(p => p.TbReCuenta)
                    .HasForeignKey(d => d.IdComanda)
                    .HasConstraintName("FK_tb_RE_Cuenta_tb_RE_Comanda");
            });

            modelBuilder.Entity<TbReDesbloqueoFiguraSalon>(entity =>
            {
                entity.ToTable("tb_RE_DesbloqueoFiguraSalon");

                entity.Property(e => e.Estado).HasMaxLength(20);

                entity.Property(e => e.FechaHora).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbReDescarga>(entity =>
            {
                entity.HasKey(e => e.IdDescarga);

                entity.ToTable("tb_RE_Descarga");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbReDescargaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.ToTable("tb_RE_DescargaDetalle");

                entity.Property(e => e.TipoReferencia)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDescargaNavigation)
                    .WithMany(p => p.TbReDescargaDetalle)
                    .HasForeignKey(d => d.IdDescarga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_RE_DescargaDetalle_tb_RE_Descarga");
            });

            modelBuilder.Entity<TbReFacturacionMesa>(entity =>
            {
                entity.ToTable("tb_RE_FacturacionMesa");

                entity.Property(e => e.NombreMesa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenciaCredito)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'CON')");
            });

            modelBuilder.Entity<TbReFiguraSalon>(entity =>
            {
                entity.ToTable("tb_RE_FiguraSalon");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaUltimaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoVisual)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbReLineaOrden>(entity =>
            {
                entity.HasKey(e => e.IdLineaOrden);

                entity.ToTable("tb_RE_LineaOrden");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.TbReLineaOrden)
                    .HasForeignKey(d => d.IdOrden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_RE_LineaOrden_tb_RE_Orden");
            });

            modelBuilder.Entity<TbReOrden>(entity =>
            {
                entity.HasKey(e => e.IdOrden);

                entity.ToTable("tb_RE_Orden");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaOrden).HasColumnType("datetime");

                entity.Property(e => e.Impresora)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdComandaNavigation)
                    .WithMany(p => p.TbReOrden)
                    .HasForeignKey(d => d.IdComanda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_RE_Orden_tb_RE_Comanda");
            });

            modelBuilder.Entity<TbReProducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("tb_RE_Producto");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EligeAcom).HasColumnName("EligeACOM");

                entity.Property(e => e.EligeMod).HasColumnName("EligeMOD");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Imagen).HasColumnType("image");

                entity.Property(e => e.Impresora)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MaxAcom).HasColumnName("MaxACOM");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TieneIs).HasColumnName("TieneIS");

                entity.Property(e => e.TieneIv).HasColumnName("TieneIV");

                entity.Property(e => e.TipoPrecio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbReReciboCortesia>(entity =>
            {
                entity.HasKey(e => e.IdReciboCortesia);

                entity.ToTable("tb_RE_ReciboCortesia");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMoneda).HasDefaultValueSql("((2))");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbReReciboCortesiaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdReciboCortesiaDetalle)
                    .HasName("PK_tb_RE_ReciboCortesiaDetalle_1");

                entity.ToTable("tb_RE_ReciboCortesiaDetalle");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbReSalon>(entity =>
            {
                entity.HasKey(e => e.IdSalon);

                entity.ToTable("tb_RE_Salon");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbReSubLineaOrden>(entity =>
            {
                entity.HasKey(e => e.IdSubLineaOrden)
                    .HasName("PK_tb_RE_ComplementoLIneaOrden");

                entity.ToTable("tb_RE_SubLineaOrden");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('MOD')");
            });

            modelBuilder.Entity<TbReUnionFiguraSalon>(entity =>
            {
                entity.ToTable("tb_RE_UnionFiguraSalon");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('ACTIVO')");

                entity.Property(e => e.Fechahora)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TbSeAuditoriaInterna>(entity =>
            {
                entity.ToTable("tb_SE_AuditoriaInterna");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DescripcionCambio)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EstacionTrabajo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TipoRegistro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
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

            modelBuilder.Entity<TbSePuntoVenta>(entity =>
            {
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

                entity.Property(e => e.IdMonedaFacturaDefecto).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdMonedaPrecio).HasDefaultValueSql("((1))");

                entity.Property(e => e.Logo).HasColumnType("image");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Front Desk')");

                entity.Property(e => e.Web)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
