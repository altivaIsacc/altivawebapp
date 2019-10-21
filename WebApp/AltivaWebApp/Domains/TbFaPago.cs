using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaPago
    {
        public long IdPago { get; set; }
        public long IdContacto { get; set; }
        public int IdTipoDocumento { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Nota { get; set; }

        public virtual TbFaTipoDocumento IdTipoDocumentoNavigation { get; set; }
    }
}
