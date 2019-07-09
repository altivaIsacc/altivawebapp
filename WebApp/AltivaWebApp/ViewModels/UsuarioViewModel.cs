using AltivaWebApp.GEDomain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class UsuarioViewModel
    {

        public int id { get; set; }

        [Required(ErrorMessage ="Codigo es requerido")]
        [StringLength(16, MinimumLength = 4)]
        public string codigo { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(40, MinimumLength = 4)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Estado es requerido")]
        [StringLength(10, MinimumLength = 4)]
        public string estado { get; set; }

        [StringLength(6, MinimumLength = 2)]
        [Required(ErrorMessage = "Inicales es requerido")]
        public string iniciales { get; set; }

        [Required(ErrorMessage = "Contraseña es requerido")]
        public string contrasena { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Confirmar Contraseña es requerido.")]
        [CompareAttribute("contrasena", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassowrd { get; set; }
        [StringLength(50, MinimumLength = 4)]
        [Required(ErrorMessage = "Inicales es requerido")]
        public string correo { get; set; }

        public IFormFile Foto { get; set; }

        public int Id_Usuario { get; set; }
        public long IdPerfil { get; set; }

        public string avatar { get; set; }


    }
}
