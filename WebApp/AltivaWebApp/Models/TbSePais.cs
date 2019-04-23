using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSePais
    {
        public int Id { get; set; }
        public string NombreEs { get; set; }
        public string NombreEn { get; set; }
        public string GentilicioEs { get; set; }
        public string GentilicioEn { get; set; }
        public bool Inactivo { get; set; }
        public string Iniciales { get; set; }
    }
}
