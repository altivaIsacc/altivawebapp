using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbPrTraslado
    {
        public long IdTraslado { get; set; }
        public long IdUsuario { get; set; }
        public long IdBodegaOrigen { get; set; }
        public long IdBodegaDestino { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool? Anulado { get; set; }
        public double CostoTraslado { get; set; }
    }
}
