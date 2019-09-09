using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbReControladorMenu
    {
        public int IdControladorMenu { get; set; }
        public int? IdReferencia { get; set; }
        public string TipoItems { get; set; }
        public int Espaciado { get; set; }
        public int Columna { get; set; }
        public double Ancho { get; set; }
        public double Alto { get; set; }
    }
}
