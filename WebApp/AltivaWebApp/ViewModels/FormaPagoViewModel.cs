using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class FormaPagoViewModel
    {
        public int IdCaja { get; set; }
        public long IdDocumento { get; set; }
        public double Monto { get; set; }
        public double TcDolar { get; set; }
        public double TcEuro { get; set; }
        public int Moneda { get; set; }
        public long IdContacto { get; set; }
        public bool EsPagoContado { get; set; }
        public int IdTipoDocumento { get; set; }
    }
}
