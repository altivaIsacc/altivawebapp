using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbPrEquivalencia
    {
        public long Id { get; set; }
        public long IdInventario { get; set; }
        public string Observaciones { get; set; }
        public bool? Unilateral { get; set; }
        public long IdEquivalencia { get; set; }

        public virtual TbPrInventario IdEquivalenciaNavigation { get; set; }
        public virtual TbPrInventario IdInventarioNavigation { get; set; }
    }
}
