using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdComisionionesSobreVentaPago
    {
        public long Id { get; set; }
        public long IdCliente { get; set; }
        public long IdMoneda { get; set; }
        public string Tipo { get; set; }
        public double Monto { get; set; }
        public string ReciboManual { get; set; }
        public string Referencia { get; set; }
        public string IdCuentaBancaria { get; set; }
        public long IdUsuario { get; set; }
        public long IdUsuarioModifica { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public double MontoDolar { get; set; }
        public double MontoEuro { get; set; }
        public double Tcdolar { get; set; }
        public double Tceuro { get; set; }
        public double Tcambio { get; set; }
        public bool Anulado { get; set; }
    }
}
