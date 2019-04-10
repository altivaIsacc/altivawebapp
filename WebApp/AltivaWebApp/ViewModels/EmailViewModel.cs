using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class EmailViewModel
    {
        [Required(ErrorMessage = "El correo es requerido")]
        public string correo { get; set; }
    }
}
