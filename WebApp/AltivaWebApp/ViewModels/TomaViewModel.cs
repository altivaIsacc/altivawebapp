using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class TomaViewModel
    {

        public long Id { get; set; }
        public DateTime FechaToma { get; set; }
        public bool EsInicial { get; set; }
        public long IdBodega { get; set; }
        public string Ordenado { get; set; }
        public long IdUsuarioCreacion { get; set; }
        public bool Borrador { get; set; }
        public bool Anulado { get; set; }

        public IList<TomaDetalleViewModel> TomaDetalle { get; set; }
    }
}
