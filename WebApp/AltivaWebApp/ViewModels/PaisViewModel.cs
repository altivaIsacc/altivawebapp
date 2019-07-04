using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class PaisViewModel
    {

        public int Id { get; set; }
        public string NombreEs { get; set; }
        public string NombreEn { get; set; }
        public string GentilicioEs { get; set; }
        public string GentilicioEn { get; set; }
        public string Iniciales { get; set; }
        public bool Inactivo { get; set; }

    }
}
