using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdComisionesSobreVentaPagoDetalle
    {
        public long Id { get; set; }
        public long IdComisionSobreVentaDetalle { get; set; }
        public long IdPagoComisionesSobreVentas { get; set; }
        public double Aplicado { get; set; }
        public double AplicadoDolar { get; set; }
        public double AplicadoEuro { get; set; }
        public double Tpcd { get; set; }
        public double Tpce { get; set; }
    }
}
