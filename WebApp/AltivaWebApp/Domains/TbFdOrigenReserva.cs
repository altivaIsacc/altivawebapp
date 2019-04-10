using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdOrigenReserva
    {
        public TbFdOrigenReserva()
        {
            TbFdReservacion = new HashSet<TbFdReservacion>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Inactivo { get; set; }

        public virtual ICollection<TbFdReservacion> TbFdReservacion { get; set; }
    }
}
