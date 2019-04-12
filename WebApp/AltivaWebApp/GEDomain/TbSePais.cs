using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AltivaWebApp.GEDomain
{
    public partial class TbSePais
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Nombre en español es requerido.")]
        public string NombreEs { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Nombre en inglés es requerido")]
        public string NombreEn { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Gentilicio en español es requerido.")]
        public string GentilicioEs { get; set; }
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Gentilicio en inglés es requerido.")]
        public string GentilicioEn { get; set; }
      
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Iniciales es Requerido")]
        public string Iniciales { get; set; }
        public bool Inactivo { get; set; }
    }
}
