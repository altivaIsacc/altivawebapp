using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class ModuloViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(50, MinimumLength = 4)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Descripción es requerido")]
        [StringLength(500, MinimumLength = 20)]
        public string Descripcion { get; set; }
        
        [StringLength(500)]
        public string Nota1 { get; set; }
        [StringLength(500)]
        public string Nota2 { get; set; }
        [Required(ErrorMessage = "Grupo es requerido")]
        [StringLength(20, MinimumLength = 4)]
        public string Grupo { get; set; }


    }
}
