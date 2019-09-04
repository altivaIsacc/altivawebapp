using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdCuentasBancarias
    {
        public long Id { get; set; }
        public string TipoCuenta { get; set; }
        public string CuentaBancaria { get; set; }
        public string Banco { get; set; }
        public string Moneda { get; set; }
        public long? IdContacto { get; set; }

        public virtual TbCrContacto IdContactoNavigation { get; set; }
    }
}
