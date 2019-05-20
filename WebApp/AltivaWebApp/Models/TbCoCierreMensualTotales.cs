using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCoCierreMensualTotales
    {
        public long Id { get; set; }
        public long IdPeriodo { get; set; }
        public double TotalDebitosColones { get; set; }
        public double TotalCreditosColones { get; set; }
        public double TotalDebitosDolar { get; set; }
        public double TotalCreditosDolar { get; set; }
        public double TotalDebitosEuro { get; set; }
        public double TotalCreditoEuro { get; set; }
        public double UtilidadColonesP { get; set; }
        public double UtilidadDolaresP { get; set; }
        public double UtilidadEuroP { get; set; }
        public double UtilidadActualColonesF { get; set; }
        public double UtilidadActualDolarF { get; set; }
        public double UtilidadActualEuroF { get; set; }
        public bool PeriodoFiscal { get; set; }
    }
}
