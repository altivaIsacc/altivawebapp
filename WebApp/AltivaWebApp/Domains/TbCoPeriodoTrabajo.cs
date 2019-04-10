using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCoPeriodoTrabajo
    {
        public long IdPeriodoTrabajo { get; set; }
        public long IdPeriodoFiscal { get; set; }
        public string Estado { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public virtual TbCoPeriodoFiscal IdPeriodoFiscalNavigation { get; set; }
    }
}
