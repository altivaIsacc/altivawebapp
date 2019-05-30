using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbCoTipoCuenta
    {
        public long IdTipoCuenta { get; set; }
        public string Nombre { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public short? NumCatalogo { get; set; }
    }
}
