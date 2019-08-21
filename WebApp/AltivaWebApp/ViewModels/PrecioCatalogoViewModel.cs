using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AltivaWebApp.ViewModels
{
    public class PrecioCatalogoViewModel
    {
        public long IdPrecioCatalogo { get; set; }
        public long IdInventario { get; set; }
        public int IdTipoPrecio { get; set; }
        public double PorcUtilidad { get; set; }
        public double PrecioSinImpuesto { get; set; }
        public double PrecioFinal { get; set; }

        public virtual TbPrInventario IdInventarioNavigation { get; set; }
        public virtual TbPrPrecios IdTipoPrecioNavigation { get; set; }
    }
}
