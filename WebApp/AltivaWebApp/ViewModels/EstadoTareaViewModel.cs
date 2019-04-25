using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class EstadoTareaViewModel
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Color { get; set; }
        public bool? EsDefecto { get; set; }
        public bool? EsInicial { get; set; }
        public bool? EsFinal { get; set; }
        public bool? Activo { get; set; }

    

    }
}
