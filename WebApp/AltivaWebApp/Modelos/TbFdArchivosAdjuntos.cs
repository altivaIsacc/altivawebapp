using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdArchivosAdjuntos
    {
        public long Id { get; set; }
        public long IdReserva { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha { get; set; }
        public long IdUsuario { get; set; }
        public string Nota { get; set; }

        public virtual TbFdReservacion IdReservaNavigation { get; set; }
    }
}
