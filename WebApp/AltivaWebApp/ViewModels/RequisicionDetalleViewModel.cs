using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class RequisicionDetalleViewModel
    {
        public long Id { get; set; }
        public long IdRequisicion { get; set; }
        public long IdInventario { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Total { get; set; }
    }
}
