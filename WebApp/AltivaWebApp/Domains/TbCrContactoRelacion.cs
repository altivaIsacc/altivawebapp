using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCrContactoRelacion
    {
        public long Id { get; set; }
        public long? IdContactoPadre { get; set; }
        public long? IdContactoHijo { get; set; }
        public string NotaRelacion { get; set; }
        public bool? Estado { get; set; }

        public virtual TbCrContacto IdContactoHijoNavigation { get; set; }
        public virtual TbCrContacto IdContactoPadreNavigation { get; set; }
    }
}
