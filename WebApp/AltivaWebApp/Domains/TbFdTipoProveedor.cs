using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdTipoProveedor
    {
        public TbFdTipoProveedor()
        {
        }

        public long Id { get; set; }
        public long IdPadre { get; set; }
        public string Nombre { get; set; }
        public bool? Inactivo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }

        
    }
}
