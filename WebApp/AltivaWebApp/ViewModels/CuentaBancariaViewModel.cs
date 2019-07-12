using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CuentaBancariaViewModel
    {
        public long Id { get; set; }
        public string TipoCuenta { get; set; }
        public string CuentaBancaria { get; set; }
        public string Banco { get; set; }
        public string Moneda { get; set; }
        public long IdContacto { get; set; }
    }
}
