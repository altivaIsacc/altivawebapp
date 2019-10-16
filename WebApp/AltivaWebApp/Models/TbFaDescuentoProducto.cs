using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaDescuentoProducto
    {
        public long IdDescuentoProducto { get; set; }
        public long IdProducto { get; set; }
        public double Porcentaje { get; set; }
        public string Tipo1 { get; set; }
    }
}
