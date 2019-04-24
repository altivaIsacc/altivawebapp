using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrInventario
    {
        public TbPrInventario()
        {
            TbPrAjusteInventario = new HashSet<TbPrAjusteInventario>();
            TbPrEquivalenciaIdEquivalenciaNavigation = new HashSet<TbPrEquivalencia>();
            TbPrEquivalenciaIdInventarioNavigation = new HashSet<TbPrEquivalencia>();
            TbPrInventarioBodega = new HashSet<TbPrInventarioBodega>();
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

        public virtual TbPrFamilia IdSubFamiliaNavigation { get; set; }
        public virtual TbPrUnidadMedida IdUnidadMedidaNavigation { get; set; }
        public virtual ICollection<TbPrAjusteInventario> TbPrAjusteInventario { get; set; }
        public virtual ICollection<TbPrEquivalencia> TbPrEquivalenciaIdEquivalenciaNavigation { get; set; }
        public virtual ICollection<TbPrEquivalencia> TbPrEquivalenciaIdInventarioNavigation { get; set; }
        public virtual ICollection<TbPrInventarioBodega> TbPrInventarioBodega { get; set; }
    }
}



