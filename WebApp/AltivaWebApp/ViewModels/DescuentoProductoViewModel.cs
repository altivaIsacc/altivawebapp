using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class DescuentoProductoViewModel
    {
        public long IdDescuentoProducto { get; set; }
        public long IdProducto { get; set; }
        public double Porcentaje { get; set; }
        public string Tipo { get; set; }
    }
}
