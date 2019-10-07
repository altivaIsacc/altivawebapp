using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrToma
    {
        public TbPrToma()
        {
            TbPrTomaDetalle = new HashSet<TbPrTomaDetalle>();
        }

        public long Id { get; set; }
        public DateTime FechaToma { get; set; }
        public bool EsInicial { get; set; }
        public long IdBodega { get; set; }
        public string Ordenado { get; set; }
        public long IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Borrador { get; set; }
        public bool Anulado { get; set; }

        public virtual TbPrBodega IdBodegaNavigation { get; set; }
        public virtual ICollection<TbPrTomaDetalle> TbPrTomaDetalle { get; set; }
    }
}
