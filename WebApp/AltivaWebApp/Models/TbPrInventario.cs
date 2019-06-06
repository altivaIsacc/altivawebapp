using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrInventario
    {
        public TbPrInventario()
        {
            TbPrAjusteInventario = new HashSet<TbPrAjusteInventario>();
            TbPrCompraDetalle = new HashSet<TbPrCompraDetalle>();
            TbPrEquivalenciaIdEquivalenciaNavigation = new HashSet<TbPrEquivalencia>();
            TbPrEquivalenciaIdInventarioNavigation = new HashSet<TbPrEquivalencia>();
            TbPrImagenInventario = new HashSet<TbPrImagenInventario>();
            TbPrInventarioBodega = new HashSet<TbPrInventarioBodega>();
            TbPrInventarioCaracteristica = new HashSet<TbPrInventarioCaracteristica>();
            TbPrOrdenDetalle = new HashSet<TbPrOrdenDetalle>();
            TbPrRequisicionDetalle = new HashSet<TbPrRequisicionDetalle>();
            TbPrTomaDetalle = new HashSet<TbPrTomaDetalle>();
        }

        public long IdInventario { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double CantidadUnidad { get; set; }
        public double ExistenciaGeneral { get; set; }
        public double CostoPromedioGeneral { get; set; }
        public double UltimoPrecioCompra { get; set; }
        public bool Inactiva { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public long IdSubFamilia { get; set; }
        public long IdUnidadMedida { get; set; }
        public int CodigoMoneda { get; set; }
        public double FactorAprovechamiento { get; set; }
        public double ImpuestoVenta { get; set; }
        public string Notas { get; set; }
        public bool HabilitarVentaDirecta { get; set; }
        public double UtilidadDeseada { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioVentaFinal { get; set; }
        public double UtilidadTemporal { get; set; }
        public double PrecioTemporal { get; set; }
        public double PrecioTemporalFinal { get; set; }
        public double UtilidadCredito { get; set; }
        public double PrecioCredito { get; set; }
        public double PrecioCreditoFinal { get; set; }
        public string DescripcionVenta { get; set; }
        public int CodigoMonedaVenta { get; set; }
        public bool HabilitarVentaOnline { get; set; }
        public long IdFamiliaOnline { get; set; }
        public string NombreCarrito { get; set; }
        public string AbreviacionFacturas { get; set; }
        public int IdMonedaVentaOnline { get; set; }
        public double PrecioVentaOnline { get; set; }
        public string SkuOnline { get; set; }

        public virtual TbPrFamilia IdSubFamiliaNavigation { get; set; }
        public virtual TbPrUnidadMedida IdUnidadMedidaNavigation { get; set; }
        public virtual ICollection<TbPrAjusteInventario> TbPrAjusteInventario { get; set; }
        public virtual ICollection<TbPrCompraDetalle> TbPrCompraDetalle { get; set; }
        public virtual ICollection<TbPrEquivalencia> TbPrEquivalenciaIdEquivalenciaNavigation { get; set; }
        public virtual ICollection<TbPrEquivalencia> TbPrEquivalenciaIdInventarioNavigation { get; set; }
        public virtual ICollection<TbPrImagenInventario> TbPrImagenInventario { get; set; }
        public virtual ICollection<TbPrInventarioBodega> TbPrInventarioBodega { get; set; }
        public virtual ICollection<TbPrInventarioCaracteristica> TbPrInventarioCaracteristica { get; set; }
        public virtual ICollection<TbPrOrdenDetalle> TbPrOrdenDetalle { get; set; }
        public virtual ICollection<TbPrRequisicionDetalle> TbPrRequisicionDetalle { get; set; }
        public virtual ICollection<TbPrTomaDetalle> TbPrTomaDetalle { get; set; }
    }
}
