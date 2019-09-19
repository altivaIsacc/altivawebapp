using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrTraslado
    {
        public TbPrTraslado()
        {
            TbPrTrasladoInventario = new HashSet<TbPrTrasladoInventario>();
        }

        public long IdTraslado { get; set; }
        public long IdUsuario { get; set; }
        public long IdBodegaOrigen { get; set; }
        public long IdBodegaDestino { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Anulado { get; set; }
        public double CostoTraslado { get; set; }
        public string Comentario { get; set; }
        public virtual TbPrBodega IdBodegaDestinoNavigation { get; set; }
        public virtual TbPrBodega IdBodegaOrigenNavigation { get; set; }
        public virtual ICollection<TbPrTrasladoInventario> TbPrTrasladoInventario { get; set; }
    }
}

