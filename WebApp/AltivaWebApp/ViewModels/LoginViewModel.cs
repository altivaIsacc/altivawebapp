using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Usuario es requerido.")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "Contraseña es requerida.")]
        public string contrasena { get; set; }
        public bool recuerdame { get; set; }
    }
}
