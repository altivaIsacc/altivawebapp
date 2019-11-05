using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCoPeriodoTrabajoResultados
    {
        public long IdPeriodoTrabajoResultado { get; set; }
        public long IdPeriodoTrabajo { get; set; }
        public long IdCuentaContable { get; set; }
        public double DebitoBase { get; set; }
        public double CreditoBase { get; set; }
        public double SaldoBase { get; set; }
        public double DebitoDolar { get; set; }
        public double CreditoDolar { get; set; }
        public double SaldoDolar { get; set; }
        public double DebitoEuro { get; set; }
        public double CreditoEuro { get; set; }
        public double SaldoEuro { get; set; }

        public virtual TbCoCuentaContable IdCuentaContableNavigation { get; set; }
        public virtual TbCoPeriodoTrabajo IdPeriodoTrabajoNavigation { get; set; }
    }
}
