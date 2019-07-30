using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class DescuentoUsuarioRangoViewModel
    {

        public int IdDescuentoUsuarioRango { get; set; }
        public int IdRebajaConfig { get; set; }
        public long IdUsuario { get; set; }
        public double MaxDescuento { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuarioCreador { get; set; }
        public string Nota { get; set; }
    }
}
