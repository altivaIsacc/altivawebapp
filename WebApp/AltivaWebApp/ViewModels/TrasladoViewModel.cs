using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class TrasladoViewModel
    {

        public long IdTraslado { get; set; }
        public long IdUsuario { get; set; }
        public long IdBodegaOrigen { get; set; }
        public long IdBodegaDestino { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Anulado { get; set; }
        public double CostoTraslado { get; set; }
        public string Comentario { get; set; }

        public IList<TrasladoInventarioViewModel> trasladoInventarioDetalle { get; set; }//si

    }
}
