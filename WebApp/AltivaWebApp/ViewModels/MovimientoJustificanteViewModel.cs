using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class MovimientoJustificanteViewModel
    {
        public long IdMovimientoJustificante { get; set; }
        public long IdMovimiento { get; set; }
        public long IdTipoJustificante { get; set; }
        public long IdUsuario { get; set; }
        public int Estado { get; set; }
        public int IdMoneda { get; set; }
        public double Monto { get; set; }      
        public double CompraDolarTc { get; set; }
        public double VentaDolatTc { get; set; }
        public double CompraEuroTc { get; set; }
        public double VentaEuroTc { get; set; }
        public string Descripcion { get; set; }
    }
}
