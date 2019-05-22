using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdDocumentos
    {
        public long Id { get; set; }
        public long IdReserva { get; set; }
        public string DireccionArchivo { get; set; }

        public virtual TbFdReservacion IdReservaNavigation { get; set; }
    }
}
