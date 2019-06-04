using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdCaracteristicaHabitacionAsoc
    {
        public long Id { get; set; }
        public long IdHabitacion { get; set; }
        public long IdCaracteristica { get; set; }
        public int Cantidad { get; set; }

        public virtual TbFdCaracteristicaHabitacion IdCaracteristicaNavigation { get; set; }
        public virtual TbFdHabitacion IdHabitacionNavigation { get; set; }
    }
}
