using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbReLineaOrden
    {
        public long IdLineaOrden { get; set; }
        public long IdOrden { get; set; }
        public long IdCuenta { get; set; }
        public long IdProducto { get; set; }
        public int Estado { get; set; }
        public bool Express { get; set; }
        public double Cantidad { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioUnitarioVenta { get; set; }
        public double? SubTotal { get; set; }
        public double? PorcentajeDescuento { get; set; }
        public double? TotalDescuento { get; set; }
        public double? PorcentajeImpuestoVenta { get; set; }
        public double? TotalImpuestoVenta { get; set; }
        public double? PorcentajeImpuestoServicio { get; set; }
        public double? TotalImpuestoServicio { get; set; }
        public double? Total { get; set; }

        public virtual TbReOrden IdOrdenNavigation { get; set; }
    }
}
