using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CajaMovimientoChequeViewModel
    {
        public long IdCajaMovimientoCheque { get; set; }
        public long IdCajaMovimiento { get; set; }
        public long Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string String { get; set; }
        public string Nota { get; set; }
        public string Portador { get; set; }
    }
}
