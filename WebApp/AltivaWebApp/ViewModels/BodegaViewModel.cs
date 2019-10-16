using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class BodegaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Produccion { get; set; }
        public bool Almacenamiento { get; set; }
        public bool SuministrosInternos { get; set; }
        public bool Consignacion { get; set; }
        public bool Estado { get; set; }
        [Required(ErrorMessage = "Usuario encargado es requerido.")]
        public int UsuarioEncargado { get; set; }
        public string Observaciones { get; set; }
    }
}
