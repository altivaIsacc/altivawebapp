using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbCoAsientoContableDetalle
    {
        public long IdDetalleAsientoContable { get; set; }
        public long IdAsientoContable { get; set; }
        public string Observacion { get; set; }
        public long IdCuentaContable { get; set; }
        public double MontoColones { get; set; }
        public double MontoDolares { get; set; }
        public double MontoEuro { get; set; }
        public bool Debe { get; set; }
        public bool Haber { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public long? IdCentrosDeGastos { get; set; }

        public virtual TbCoAsientoContable IdAsientoContableNavigation { get; set; }
        public virtual TbCoCuentaContable IdCuentaContableNavigation { get; set; }
    }
}
