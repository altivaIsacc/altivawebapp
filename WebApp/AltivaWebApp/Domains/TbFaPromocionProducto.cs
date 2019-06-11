using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaPromocionProducto
    {
        public int IdPromocionProducto { get; set; }
        public int IdRebajaConfig { get; set; }
        public string Clave { get; set; }
        public long IdCliente { get; set; }
        public bool EntreFechas { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Nota { get; set; }
        public bool EsTipo1 { get; set; }
        public long IdTipoInventarioRef { get; set; }
        public int CantTipo1Ref { get; set; }
        public long IdTipo1InventarioPromo { get; set; }
        public int CantTipo1Promo { get; set; }
        public double PorcTipo1DescuentoPromo { get; set; }
        public bool? EsTipo2 { get; set; }
        public double CantTipo2Ref { get; set; }
        public double PorcTipo2Descuento { get; set; }
        public long IdTipo2Contacto { get; set; }

        public virtual TbFaRebajaConfig IdRebajaConfigNavigation { get; set; }
    }
}
