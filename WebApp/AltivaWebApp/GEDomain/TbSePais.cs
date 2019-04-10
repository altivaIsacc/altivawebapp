using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AltivaWebApp.GEDomain
{
    public partial class TbSePais
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Nombre en español es Requerido")]
        public string NombreEs { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Nombre en ingles es Requerido")]
        public string NombreEn { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Gentilicio en español es Requerido")]
        public string GentilicioEs { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Gentilicio en ingles es Requerido")]
        public string GentilicioEn { get; set; }
      
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Iniciales es Requerido")]
        public string Iniciales { get; set; }
        public bool Inactivo { get; set; }
    }
}
