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
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Nombre es Requerido")]
        public string Nombre { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Correo es Requerido")]
        public string Correo { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Telfono es Requerido")]
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }

        [StringLength(15, MinimumLength = 2)]
        [Required(ErrorMessage = "Cédula es Requerida")]
        public string CedJuridica { get; set; }


        public IFormFile Foto{ get; set; }

        public string Bd { get; set; }

        public bool Estado { get; set; }
        [StringLength(200, MinimumLength = 10)]
        [Required(ErrorMessage = "Nombre es Requerido")]
        public string Direccion { get; set; }
        public int Id_GE { get; set; }

    }
}
