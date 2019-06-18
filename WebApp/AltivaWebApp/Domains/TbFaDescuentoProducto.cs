using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaDescuentoProducto
    {
        public long IdDescuentoProducto { get; set; }
        public long IdProducto { get; set; }
        public double Porcentaje { get; set; }
        public string Tipo { get; set; }
    }
}
