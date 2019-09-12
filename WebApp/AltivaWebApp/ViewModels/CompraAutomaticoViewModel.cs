using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CompraAutomaticoViewModel
    {

        public long IdInventario { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double ExistenciaGeneral { get; set; }
        public double emin { get; set; }
        public double emed { get; set; }
        public double emax { get; set; }
        public double etotal { get; set; }
    }
}
