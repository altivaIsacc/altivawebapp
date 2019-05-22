using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdComisionSobreVentasDetalle
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public bool Anulado { get; set; }
        public long IdFacturaDetalle { get; set; }
        public long IdClienteComisionista { get; set; }
        public long IdServicio { get; set; }
        public string Descripcion { get; set; }
        public double Porcentaje { get; set; }
        public double PrecioColon { get; set; }
        public double PrecioDolar { get; set; }
        public double PrecioEuro { get; set; }
        public double Cantidad { get; set; }
        public double SubTotalColon { get; set; }
        public double SubTotalDolar { get; set; }
        public double SubTotalEuro { get; set; }
        public double SubTotalGravadoColones { get; set; }
        public double SubTotalGravadoDolar { get; set; }
        public double SubTotalGravadoEuro { get; set; }
        public double SubTotalComisionColones { get; set; }
        public double SubTotalComisionDolar { get; set; }
        public double SubTotalComisionEuro { get; set; }
        public double ImpuestoVenta { get; set; }
        public double ImpuestoVentaDolar { get; set; }
        public double ImpuestoVentaEuro { get; set; }
        public double ImpuestoServicio { get; set; }
        public double ImpuestoServicioDolar { get; set; }
        public double ImpuestoServicioEuro { get; set; }
        public double TotalColones { get; set; }
        public double TotalDolar { get; set; }
        public double TotalEuro { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
    }
}
