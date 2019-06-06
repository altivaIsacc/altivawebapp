using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class TomaDetalleViewModel
    {
        public long Id { get; set; }
        public long IdInventario { get; set; }
        public long IdFamilia { get; set; }
        public double Inicial { get; set; }
        public double Entradas { get; set; }
        public double Salidas { get; set; }
        public double Existencia { get; set; }
        public double Toma { get; set; }
        public double CostoPromedio { get; set; }
        public long IdToma { get; set; }
    }
}
