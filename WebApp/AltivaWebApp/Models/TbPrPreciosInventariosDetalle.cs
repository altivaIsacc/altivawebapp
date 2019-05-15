using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrPreciosInventariosDetalle
    {
        public long Id { get; set; }
        public long IdPrecioInventario { get; set; }
        public long IdInventario { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double PrecioSinImpuestoActual { get; set; }
        public double PrecioConImpuestoActual { get; set; }
        public double UtilidadActual { get; set; }
        public double CostoActual { get; set; }
        public double NuevaUtilidad { get; set; }
        public double NuevoPrecioSinImpuesto { get; set; }
        public double NuevoPrecioConImpuesto { get; set; }
        public bool ImpuestoVenta { get; set; }
    }
}
