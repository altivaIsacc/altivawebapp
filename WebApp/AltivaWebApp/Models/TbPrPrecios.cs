using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrPrecios
    {
        public TbPrPrecios()
        {
            TbFdTipoCliente = new HashSet<TbFdTipoCliente>();
            TbPrPrecioCatalogo = new HashSet<TbPrPrecioCatalogo>();
            TbSePuntoVenta = new HashSet<TbSePuntoVenta>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Anulado { get; set; }
        public long IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TbFdTipoCliente> TbFdTipoCliente { get; set; }
        public virtual ICollection<TbPrPrecioCatalogo> TbPrPrecioCatalogo { get; set; }
        public virtual ICollection<TbSePuntoVenta> TbSePuntoVenta { get; set; }
    }
}
