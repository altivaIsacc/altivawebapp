using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdNotaCreditoNddetalle
    {
        public long Id { get; set; }
        public long IdNotaDebito { get; set; }
        public double Monto { get; set; }
        public double Aplicado { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double AplicadoPago { get; set; }
        public long IdNotaCredito { get; set; }
    }
}
