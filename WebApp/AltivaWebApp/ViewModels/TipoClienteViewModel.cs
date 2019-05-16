using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class TipoClienteViewModel
    {
        public long Id { get; set; }
        public long? IdPadre { get; set; }
        public string Nombre { get; set; }
        public bool? Inactivo { get; set; }
    }
}
