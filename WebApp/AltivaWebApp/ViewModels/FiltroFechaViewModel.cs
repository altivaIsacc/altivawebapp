using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class FiltroFechaViewModel
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public bool Filtrando { get; set; }
    }
}
