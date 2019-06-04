using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbReFacturacionMesa
    {
        public long Id { get; set; }
        public long IdFactura { get; set; }
        public long IdComanda { get; set; }
        public long IdCuentaComanda { get; set; }
        public long IdMesa { get; set; }
        public double ExtraTipColon { get; set; }
        public double ExtraTipDolar { get; set; }
        public double ExtraTipEuro { get; set; }
        public string Tipo { get; set; }
        public string ReferenciaCredito { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public string NombreMesa { get; set; }
    }
}
