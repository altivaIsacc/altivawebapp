using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdContratoTipoHabitacion
    {
        public long Id { get; set; }
        public long IdContrato { get; set; }
        public long IdTipoHabitacion { get; set; }

        public virtual TbFdContrato IdContratoNavigation { get; set; }
        public virtual TbFdTipoHabitacion IdTipoHabitacionNavigation { get; set; }
    }
}
