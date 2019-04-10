using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class PerfilViewModel
    {
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Nombre es Requerido")]
        public string Nombre { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
