using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaTipoJustificante
    {
        public TbFaTipoJustificante()
        {
            TbFaMovimientoJustificante = new HashSet<TbFaMovimientoJustificante>();
        }

        public long IdTipoJustificante { get; set; }
        public long Nombre { get; set; }
        public int Estado { get; set; }
        public bool? Cxp { get; set; }
        public bool? Cxc { get; set; }

        public virtual ICollection<TbFaMovimientoJustificante> TbFaMovimientoJustificante { get; set; }
    }
}
