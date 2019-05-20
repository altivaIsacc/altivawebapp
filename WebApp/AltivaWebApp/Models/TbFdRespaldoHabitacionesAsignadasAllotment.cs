using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdRespaldoHabitacionesAsignadasAllotment
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdReservacionAllotment { get; set; }
        public long IdReservacionHospedajeAllotment { get; set; }
        public long IdTipoHabitacion { get; set; }
        public long IdHabitacion { get; set; }
        public string Estado { get; set; }
        public long IdReserva { get; set; }
    }
}
