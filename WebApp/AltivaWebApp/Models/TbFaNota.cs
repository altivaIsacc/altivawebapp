using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaNota
    {
        public long IdNotaCredito { get; set; }
        public long IdContacto { get; set; }
        public int IdTipoDocumento { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Nota { get; set; }

        public virtual TbFaTipoDocumento IdTipoDocumentoNavigation { get; set; }
    }
}
