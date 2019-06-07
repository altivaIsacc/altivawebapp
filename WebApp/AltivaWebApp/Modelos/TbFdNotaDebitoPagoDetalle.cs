using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdNotaDebitoPagoDetalle
    {
        public long Id { get; set; }
        public long IdNotaDebito { get; set; }
        public double Monto { get; set; }
        public double Aplicado { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double AplicadoPago { get; set; }
        public long IdPagCliente { get; set; }

        public virtual TbFdNotasDebito IdNotaDebitoNavigation { get; set; }
        public virtual TbFdPagoCliente IdPagClienteNavigation { get; set; }
    }
}
