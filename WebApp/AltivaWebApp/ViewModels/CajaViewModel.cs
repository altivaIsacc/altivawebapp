using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CajaViewModel
    {
        public long IdCaja { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }
        public int? Estado { get; set; }

        public IList<CajaAperturaDenominacionViewModel> TbFaCajaAperturaDenominacion { get; set; }
    }
}
