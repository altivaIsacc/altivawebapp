using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrInventarioCaracteristica
    {
        public long IdCaracteristicas { get; set; }
        public string Caracteristicas { get; set; }
        public long IdInventario { get; set; }

        public virtual TbPrInventario IdInventarioNavigation { get; set; }
    }
}
