using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class InventarioViewModel
    {
        public long IdInventario { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public float CantidadUnidad { get; set; }
        public float ExistenciaGeneral { get; set; }
        public float CostoPromedioGeneral { get; set; }
        public float UltimoPrecioCompra { get; set; }
        public bool Inactiva { get; set; }       
        public long IdUsuario { get; set; }
        public long IdSubFamilia { get; set; }
        public long IdUnidadMedida { get; set; }
        public int CodigoMoneda { get; set; }
        public float FactorAprovechamiento { get; set; }
        public float ImpuestoVenta { get; set; }
        public string Notas { get; set; }
        public bool HabilitarVentaDirecta { get; set; }
        public float UtilidadDeseada { get; set; }
        public float PrecioVenta { get; set; }
        public float PrecioVentaFinal { get; set; }
        public float UtilidadTemporal { get; set; }
        public float PrecioTemporal { get; set; }
        public float PrecioTemporalFinal { get; set; }
        public float UtilidadCredito { get; set; }
        public float PrecioCredito { get; set; }
        public float PrecioCreditoFinal { get; set; }
        public string DescripcionVenta { get; set; }
        public int CodigoMonedaVenta { get; set; }
        public bool HabilitarVentaOnline { get; set; }
        public string NombreCarrito { get; set; }
        public string AbreviacionFactura { get; set; }
        public int CodigoMonedaOnline { get; set; }
        public float PrecioVentaOnline { get; set; }
        public int IdFamiliaOnline { get; set; }
        public string SkuOnline { get; set; }








        public IList<TbPrInventarioBodega>  Bodegas { get; set; }
    }
}
