using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdDesgloceReservaNotas
    {
        public long Id { get; set; }
        public long IdReservacion { get; set; }
        public DateTime FechaRelacion { get; set; }
        public double Monto { get; set; }
        public double Aplicado { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdNotaCredito { get; set; }
        public double AplicadoNotaCredito { get; set; }
        public int? IdMoneda { get; set; }

        public virtual TbFdNotasCredito IdNotaCreditoNavigation { get; set; }
        public virtual TbFdReservacion IdReservacionNavigation { get; set; }
    }
}
