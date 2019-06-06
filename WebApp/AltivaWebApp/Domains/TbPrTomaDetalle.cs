using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrTomaDetalle
    {
        public long Id { get; set; }
        public long IdInventario { get; set; }
        public double Inicial { get; set; }
        public double Entradas { get; set; }
        public double Salidas { get; set; }
        public double Existencia { get; set; }
        public double Toma { get; set; }
        public double CostoPromedio { get; set; }
        public long IdToma { get; set; }

        public virtual TbPrInventario IdInventarioNavigation { get; set; }
        public virtual TbPrToma IdTomaNavigation { get; set; }
    }
}
