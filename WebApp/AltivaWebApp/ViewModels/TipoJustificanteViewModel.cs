using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class TipoJustificanteViewModel
    {

        public long IdTipoJustificante { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public bool? Cxp { get; set; }
        public bool? Cxc { get; set; }
    }
}
