using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class DescuentoUsuarioViewModel
    {
        public int IdDescuentoUsuario { get; set; }
        public int IdRebajaConfig { get; set; }
        public long IdUsuario { get; set; }
        public double MaxDescuento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuarioCreador { get; set; }
        public string Nota { get; set; }
    }
}
