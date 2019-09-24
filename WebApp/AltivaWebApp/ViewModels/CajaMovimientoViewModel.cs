using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CajaMovimientoViewModel
    {

        public long IdCajaMovimiento { get; set; }
        public long IdCategoriaFlujo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Estado { get; set; }
        public int IdMoneda { get; set; }
        public double MontoBase { get; set; }
        public double MontoDolar { get; set; }
        public double MontoEuro { get; set; }
        public double CompraDolarTc { get; set; }
        public double VentaDolarTc { get; set; }
        public double CompraEuroTc { get; set; }
        public double VentaEuroTc { get; set; }
        public int? IdTipoCajaMovimiento { get; set; }
        public long IdCaja { get; set; }
        public long IdMovimiento { get; set; }

    }
}
