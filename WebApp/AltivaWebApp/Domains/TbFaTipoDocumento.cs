using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaTipoDocumento
    {
        public TbFaTipoDocumento()
        {
            TbFaMovimiento = new HashSet<TbFaMovimiento>();
            TbFaNota = new HashSet<TbFaNota>();
        }

        public int IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public bool EsNota { get; set; }
        public bool CxP { get; set; }
        public bool Cxc { get; set; }
        public bool? EsDebito { get; set; }

        public virtual ICollection<TbFaMovimiento> TbFaMovimiento { get; set; }
        public virtual ICollection<TbFaNota> TbFaNota { get; set; }
    }
}
