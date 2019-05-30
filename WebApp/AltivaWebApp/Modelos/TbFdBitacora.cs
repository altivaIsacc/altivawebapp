using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdBitacora
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public long IdReferencia { get; set; }
        public string TipoReferencia { get; set; }
    }
}
