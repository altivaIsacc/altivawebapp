using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class MovimientoDetalleViewModel
    {
        public long IdMovimientoDetalle { get; set; }
        public long IdMovimientoDesde { get; set; }
        public long IdMovimientoHasta { get; set; }
        public double Aplicado { get; set; }
        public double CompraDolarTc { get; set; }
        public double VentaDolarTc { get; set; }
        public double CompraEuroTc { get; set; }
        public double VentaEuroTc { get; set; }
        public double IdMoneda { get; set; }


    }
}
