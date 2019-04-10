using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class ViewModelAdjunto
    {
        [StringLength(1000, MinimumLength = 10)]
        [Required(ErrorMessage = "Mensaje es Requerido")]
        public string mensaje { get; set; }
        public string tipoMensaje { get; set; }
        public string tipoReferencia { get; set; }
        public int id { get; set; }
        public IFormFile[] Files { get; set; }

        public string[] Usuarios { get; set; }
    }
}
