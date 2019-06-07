using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbCpPago
    {
        public long IdPago { get; set; }
        public long IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public int IdMoneda { get; set; }
        public double TotalDebitos { get; set; }
        public bool Anulado { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string CuentaBanco { get; set; }
        public double MontoPago { get; set; }
        public double SaldoDisponible { get; set; }
        public double TipoCambioEuro { get; set; }
        public double TipoCambioDolar { get; set; }
    }
}
