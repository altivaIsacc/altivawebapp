using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrTipoProveedor
    {
        public int IdTipoProveedor { get; set; }
        public string Descripcion { get; set; }
        public bool Inactiva { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
    }
}
