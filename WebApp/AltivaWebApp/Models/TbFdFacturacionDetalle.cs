using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdFacturacionDetalle
    {
        public long Id { get; set; }
        public long IdFactura { get; set; }
        public long IdCuentaEnCasaDetalle { get; set; }
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fdesde { get; set; }
        public DateTime Fhasta { get; set; }
        public long Codigo { get; set; }
        public double Tarifa { get; set; }
        public double TarifaEuro { get; set; }
        public double TarifaDolar { get; set; }
        public double SubTotalExcento { get; set; }
        public double SubTotalExcentoDolar { get; set; }
        public double SubTotalExcentoEuro { get; set; }
        public double SubTotalGravado { get; set; }
        public double SubTotalGravadoDolar { get; set; }
        public double SubTotalGravadoEuro { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalDescuentoDolar { get; set; }
        public double TotalDescuentoEuro { get; set; }
        public double Descuento { get; set; }
        public double ImpuestoVentas { get; set; }
        public double ImpuestoVentasDolar { get; set; }
        public double ImpuestoVentasEuro { get; set; }
        public double ImpuestoServicios { get; set; }
        public double ImpuestoServiciosDolar { get; set; }
        public double ImpuestoServiciosEuro { get; set; }
        public double Total { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }

        public virtual TbFdFacturacion IdFacturaNavigation { get; set; }
    }
}
