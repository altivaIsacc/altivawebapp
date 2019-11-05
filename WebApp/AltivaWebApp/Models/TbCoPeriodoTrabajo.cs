using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCoPeriodoTrabajo
    {
        public TbCoPeriodoTrabajo()
        {
            TbCoAsientoContable = new HashSet<TbCoAsientoContable>();
            TbCoPeriodoTrabajoResultados = new HashSet<TbCoPeriodoTrabajoResultados>();
        }

        public long IdPeriodoTrabajo { get; set; }
        public long IdPeriodoFiscal { get; set; }
        public string Estado { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public virtual TbCoPeriodoFiscal IdPeriodoFiscalNavigation { get; set; }
        public virtual ICollection<TbCoAsientoContable> TbCoAsientoContable { get; set; }
        public virtual ICollection<TbCoPeriodoTrabajoResultados> TbCoPeriodoTrabajoResultados { get; set; }
    }
}
