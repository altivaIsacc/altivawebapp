using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrTipoAjusteInventario
    {
        public long IdTipoAjusteInventario { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuarioMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaMod { get; set; }
    }
}
