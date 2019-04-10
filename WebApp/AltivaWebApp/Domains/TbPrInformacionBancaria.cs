using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrInformacionBancaria
    {
        public long Id { get; set; }
        public string NombreBanco { get; set; }
        public string CuentaCliente { get; set; }
        public bool Pagos { get; set; }
        public string CuentaBanco { get; set; }
        public long CodigoMoneda { get; set; }
        public int IdProveedor { get; set; }
    }
}
