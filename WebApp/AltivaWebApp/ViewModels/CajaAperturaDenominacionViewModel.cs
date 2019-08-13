using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CajaAperturaDenominacionViewModel
    {
        public long IdCajaApertura { get; set; }
        public long? IdCaja { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }
        public long? IdDenominacion { get; set; }
        public double? Cantidad { get; set; }
        public double? Monto { get; set; }

    }
}
