using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdDesgloceReserva
    {
        public long Id { get; set; }
        public int IdReservacion { get; set; }
        public DateTime FechaRelacion { get; set; }
        public double Monto { get; set; }
        public double Aplicado { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdPagoCliente { get; set; }
        public double AplicadoPagoCliente { get; set; }

        public virtual TbFdPagoCliente IdPagoClienteNavigation { get; set; }
    }
}
