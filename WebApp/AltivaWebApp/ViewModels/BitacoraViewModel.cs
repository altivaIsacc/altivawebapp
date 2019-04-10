using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class BitacoraViewModel
    {
        public long Id { get; set; }
        public long? IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string nombre { get; set; }
        public string nombreUsuario { get; set; }
        public string Descripcion { get; set; }
        public long? IdReferencia { get; set; }
        public string TipoReferencia { get; set; }
        public DateTime Fecha1 { get; set; }
        public DateTime Fecha2 { get; set; }
    }
}
