using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCoCentrosDeGastos
    {
        public TbCoCentrosDeGastos()
        {
            TbPrAjusteInventario = new HashSet<TbPrAjusteInventario>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public long IdUsuarioCreacion { get; set; }
        public long IdUsuarioMod { get; set; }
        public long Nivel { get; set; }
        public long ParentId { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }

        public virtual ICollection<TbPrAjusteInventario> TbPrAjusteInventario { get; set; }
    }
}
