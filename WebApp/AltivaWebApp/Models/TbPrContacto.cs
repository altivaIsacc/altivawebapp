using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrContacto
    {
        public int IdContacto { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public int IdProveedor { get; set; }
    }
}
