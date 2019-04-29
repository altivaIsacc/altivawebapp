using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class TipoTareaViewModel
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Color { get; set; }
        public bool? ControlaFechaLimite { get; set; }
        public double DiasFechaLimite { get; set; }
        public bool? EsTipoDefecto { get; set; }
        public bool? Activo { get; set; }
        
    }
}
