using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaCajaMovimientoTarjeta
    {
        public long IdCajaMovimientoTarjeta { get; set; }
        public long IdCajaMovimiento { get; set; }
        public string Autorizacion { get; set; }
        public string Voucher { get; set; }

        public virtual TbFaCajaMovimiento IdCajaMovimientoNavigation { get; set; }
    }
}
