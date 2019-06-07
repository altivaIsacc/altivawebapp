using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbReSubLineaOrden
    {
        public long IdSubLineaOrden { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public long IdLineaOrden { get; set; }
        public long IdComplemento { get; set; }
        public double PrecioUnitarioVenta { get; set; }
        public double PorcentajeDescuento { get; set; }
        public double TotalDescuento { get; set; }
        public double PorcentajeImpuestoVenta { get; set; }
        public double TotalImpuestoVenta { get; set; }
        public double PorcentajeImpuestoServicio { get; set; }
        public double TotalImpuestoServicio { get; set; }
        public double Total { get; set; }
    }
}
