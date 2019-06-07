using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbBaMovimientoBancariosDetalle
    {
        public long Id { get; set; }
        public long IdMovimiento { get; set; }
        public string Observacion { get; set; }
        public bool Debe { get; set; }
        public bool Haber { get; set; }
        public double MontoColones { get; set; }
        public double MontoDolar { get; set; }
        public double MontoEuro { get; set; }
        public long IdCuentaContable { get; set; }
        public long IdCuentaCosto { get; set; }
        public double Tccdolar { get; set; }
        public double Tcvdolar { get; set; }
        public double Tcceuro { get; set; }
        public double Tcveuro { get; set; }
    }
}
