using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CentroCostosViewModel
    {
        public int Id { get; set; }
        public long IdUsuario { get; set; }
        public double? Costo { get; set; }
    }
}
