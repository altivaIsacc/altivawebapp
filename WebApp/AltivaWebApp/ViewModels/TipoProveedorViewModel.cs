using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class TipoProveedorViewModel
    {
        public long Id { get; set; }
        public long? IdPadre { get; set; }
        public string Nombre { get; set; }
        public bool Inactivo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
