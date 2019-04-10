using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdJustificacion
    {
        public long Id { get; set; }
        public long IdDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public long IdReferencia { get; set; }
        public string TipoReferencia { get; set; }
        public DateTime Fecha { get; set; }
        public string Movimiento { get; set; }
        public string Justificacion { get; set; }
        public long IdUsuario { get; set; }
    }
}
