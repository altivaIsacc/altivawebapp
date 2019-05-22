using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbPrInventarioCaracteristica
    {
        public long IdCaracteristicas { get; set; }
        public string Caracteristicas { get; set; }
        public long IdInventario { get; set; }

        public virtual TbPrInventario IdInventarioNavigation { get; set; }
    }
}
