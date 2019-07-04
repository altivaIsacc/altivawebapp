
using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//creada po lenin
namespace AltivaWebApp.ViewModels
{
    public class FlujoCategoriaViewModel
    {
   
        public long IdCategoriaFlujo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public int IdTipoFlujo { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Estado { get; set; }

    }
}
