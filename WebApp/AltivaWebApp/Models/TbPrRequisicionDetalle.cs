using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrRequisicionDetalle
    {
        public long Id { get; set; }
        public long IdRequisicion { get; set; }
        public long IdInventario { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Total { get; set; }

        public virtual TbPrInventario IdInventarioNavigation { get; set; }
        public virtual TbPrRequisicion IdRequisicionNavigation { get; set; }
    }
}
