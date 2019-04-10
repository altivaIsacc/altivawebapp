using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdHabitacion
    {
        public TbFdHabitacion()
        {
            TbFdCaracteristicaHabitacionAsoc = new HashSet<TbFdCaracteristicaHabitacionAsoc>();
            TbFdCuentaEnCasa = new HashSet<TbFdCuentaEnCasa>();
        }

        public long Id { get; set; }
        public string Codigo { get; set; }
        public long TipoHabitacion { get; set; }
        public string Descripcion { get; set; }
        public string Extension { get; set; }
        public bool Eliminada { get; set; }
        public int MaximoAdulto { get; set; }
        public int MaximoNiño { get; set; }
        public string Ocupacion { get; set; }
        public bool Sucia { get; set; }

        public virtual TbFdTipoHabitacion TipoHabitacionNavigation { get; set; }
        public virtual ICollection<TbFdCaracteristicaHabitacionAsoc> TbFdCaracteristicaHabitacionAsoc { get; set; }
        public virtual ICollection<TbFdCuentaEnCasa> TbFdCuentaEnCasa { get; set; }
    }
}
