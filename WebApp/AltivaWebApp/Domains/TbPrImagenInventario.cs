using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrImagenInventario
    {
        public long IdImagen { get; set; }
        public string Imagen { get; set; }
        public long IdInventario { get; set; }

        public virtual TbPrInventario IdInventarioNavigation { get; set; }
    }
}
