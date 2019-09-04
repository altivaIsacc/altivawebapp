using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdCuentaEnCasaPagoCliente
    {
        public long Id { get; set; }
        public long IdCuentaEnCasa { get; set; }
        public long IdPagoCliente { get; set; }
        public double Aplicado { get; set; }
        public double Facturado { get; set; }

        public virtual TbFdCuentaEnCasa IdCuentaEnCasaNavigation { get; set; }
        public virtual TbFdPagoCliente IdPagoClienteNavigation { get; set; }
    }
}
