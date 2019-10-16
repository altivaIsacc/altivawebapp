using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CajaMovimientoTarjetaViewModel
    {
        public long IdCajaMovimeintoTarjeta { get; set; }
        public long IdCajaMovimiento { get; set; }
        public string Autorizacion { get; set; }
        public string Voucher { get; set; }
    }
}
