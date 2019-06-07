using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdAuditoriaRooming
    {
        public long Id { get; set; }
        public long IdCliente { get; set; }
        public long IdTipoHabitacion { get; set; }
        public string TipoHabitacion { get; set; }
        public string Huesped { get; set; }
        public int CantidadAdulto { get; set; }
        public int CantidadNiño { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public long IdAuditoria { get; set; }
        public long IdHabitacion { get; set; }
        public long IdReservacion { get; set; }

        public virtual TbFdCliente IdClienteNavigation { get; set; }
        public virtual TbFdTipoHabitacion IdTipoHabitacionNavigation { get; set; }
    }
}
