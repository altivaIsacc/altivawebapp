using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CategoriaGastoVIewModel
    {
        public int Id { get; set; }
        public bool Tipo { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
    }
}
