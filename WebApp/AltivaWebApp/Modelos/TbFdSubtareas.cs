using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdSubtareas
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public long? IdTarea { get; set; }

        public virtual TbFdTarea IdTareaNavigation { get; set; }
    }
}
