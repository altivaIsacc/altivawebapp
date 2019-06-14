using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class PromocionProductoViewModel
    {
        public int IdPromocionProducto { get; set; }
        public int IdRebajaConfig { get; set; }
        public bool ConClaveAutorizacion { get; set; }
        public string Clave { get; set; }
        public bool VentaCliente { get; set; }
        public long IdCliente { get; set; }
        public bool EntreFechas { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Nota { get; set; }
        public bool FamiliaCliente { get; set; }
        public long IdFamiliaCliente { get; set; }
        public bool EsTipo1 { get; set; }
        public int CantTipo1Ref { get; set; }
        public long IdTipoInventarioRef { get; set; }
        public int CantTipo1Promo { get; set; }
        public long IdTipo1InventarioPromo { get; set; }
        public double PorcTipo1DescuentoPromo { get; set; }
        public bool? EsTipo2 { get; set; }
        public double CantTipo2Ref { get; set; }
        public long IdTipo2Inventario { get; set; }
        public double PorcTipo2Descuento { get; set; }
        public bool FamiliaProveedor { get; set; }
        public long IdProveedor { get; set; }
    }
}
