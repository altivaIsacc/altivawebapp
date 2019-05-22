using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbCpPagoDetallado
    {
        public long IdPagoDetallado { get; set; }
        public long IdPago { get; set; }
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumFactura { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public double Saldo { get; set; }
        public double AplicadoDetalle { get; set; }
        public double AplicadoPago { get; set; }
    }
}
