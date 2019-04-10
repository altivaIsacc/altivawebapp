using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdReservacionServicioTarifa
    {
        public long Id { get; set; }
        public long IdReservacion { get; set; }
        public long IdReservacionServicio { get; set; }
        public long IdServicio { get; set; }
        public double Tarifa { get; set; }
        public DateTime Fecha { get; set; }
    }
}
