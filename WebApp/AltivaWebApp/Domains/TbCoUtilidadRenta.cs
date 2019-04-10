using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCoUtilidadRenta
    {
        public long Id { get; set; }
        public long IdPeriodoFiscal { get; set; }
        public double TotalUtilidadBrutaColones { get; set; }
        public double TotalUtilidadPagarColones { get; set; }
        public double TotalUtilidadBrutaDolar { get; set; }
        public double TotalUtilidadPagarDolar { get; set; }
        public double TotalUtilidadBrutaEuro { get; set; }
        public double TotalUtilidadPagarEuro { get; set; }
        public double Tccd { get; set; }
        public double Tcvd { get; set; }
        public double Tcce { get; set; }
        public double Tcve { get; set; }
        public double Porcentaje { get; set; }
    }
}
