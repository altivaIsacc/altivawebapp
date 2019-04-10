using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdCaracteristicaHabitacion
    {
        public TbFdCaracteristicaHabitacion()
        {
            TbFdCaracteristicaHabitacionAsoc = new HashSet<TbFdCaracteristicaHabitacionAsoc>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Inactivo { get; set; }

        public virtual ICollection<TbFdCaracteristicaHabitacionAsoc> TbFdCaracteristicaHabitacionAsoc { get; set; }
    }
}
