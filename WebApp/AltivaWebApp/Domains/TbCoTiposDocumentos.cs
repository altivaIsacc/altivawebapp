using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCoTiposDocumentos
    {
        public TbCoTiposDocumentos()
        {
            TbCoAsientoContable = new HashSet<TbCoAsientoContable>();
        }

        public long IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public bool? Automatico { get; set; }

        public virtual ICollection<TbCoAsientoContable> TbCoAsientoContable { get; set; }
    }
}
