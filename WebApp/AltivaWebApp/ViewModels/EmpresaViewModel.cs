using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class EmpresaViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Nombre es requerido.")]
        public string Nombre { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Correo es requerido.")]
        public string Correo { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Teléfono es requerido.")]
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Cédula es requerida.")]
        public string CedJuridica { get; set; }

        [Required(ErrorMessage = "Foto es requerida.")]
        public IFormFile Foto{ get; set; }

        public string Bd { get; set; }

        public bool Estado { get; set; }
        [StringLength(200, MinimumLength = 10,  ErrorMessage = "Debe contener al menos 10 caracteres.")]
        [Required(ErrorMessage = "Dirección es requerida.")]
        public string Direccion { get; set; }
        public int Id_GE { get; set; }

    }
}
