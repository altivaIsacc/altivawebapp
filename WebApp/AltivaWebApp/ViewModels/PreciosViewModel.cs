using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class PreciosViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Anulado { get; set; }
        public long IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
