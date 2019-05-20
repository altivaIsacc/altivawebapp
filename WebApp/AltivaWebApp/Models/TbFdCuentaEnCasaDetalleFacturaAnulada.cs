using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdCuentaEnCasaDetalleFacturaAnulada
    {
        public long Id { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fdesde { get; set; }
        public DateTime Fhasta { get; set; }
        public long Codigo { get; set; }
        public double Tarifa { get; set; }
        public double SubTotalExcento { get; set; }
        public double SubTotalGravado { get; set; }
        public double TotalDescuento { get; set; }
        public double Descuento { get; set; }
        public double ImpuestoVentas { get; set; }
        public double ImpuestoServicios { get; set; }
        public double Total { get; set; }
        public double TotalPendiente { get; set; }
    }
}
