using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrRequisicion
    {
        public TbPrRequisicion()
        {
            TbPrRequisicionDetalle = new HashSet<TbPrRequisicionDetalle>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdDepartamento { get; set; }
        public bool Anulado { get; set; }
        public long IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public double Total { get; set; }

        public virtual TbPrDepartamento IdDepartamentoNavigation { get; set; }
        public virtual ICollection<TbPrRequisicionDetalle> TbPrRequisicionDetalle { get; set; }
    }
}
