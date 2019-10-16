using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaMovimientoDetalle
    {
        public long IdMovimientoDetalle { get; set; }
        public long IdMovimientoDesde { get; set; }
        public long IdMovimientoHasta { get; set; }
        public double AplicadoBase { get; set; }
        public double AplicadoDolar { get; set; }
        public double AplicadoEuro { get; set; }
        public double CompraDolarTc { get; set; }
        public double VentaDolarTc { get; set; }
        public double CompraEuroTc { get; set; }
        public double VentaEuroTc { get; set; }
        public DateTime Fecha { get; set; }

        public virtual TbFaMovimiento IdMovimientoDesdeNavigation { get; set; }
        public virtual TbFaMovimiento IdMovimientoHastaNavigation { get; set; }
    }
}
