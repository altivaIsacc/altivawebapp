using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCoPeriodoFiscal
    {
        public TbCoPeriodoFiscal()
        {
            TbCoPeriodoTrabajo = new HashSet<TbCoPeriodoTrabajo>();
        }

        public long IdPeriodoFiscal { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TbCoPeriodoTrabajo> TbCoPeriodoTrabajo { get; set; }
    }
}
