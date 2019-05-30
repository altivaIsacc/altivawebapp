using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdPagoDetalleFactura
    {
        public long Id { get; set; }
        public long IdFactura { get; set; }
        public long IdPagoCliente { get; set; }
        public double Monto { get; set; }
        public double Aplicado { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double AplicadoPagoCliente { get; set; }
        public bool Prepago { get; set; }

        public virtual TbFdPagoCliente IdPagoClienteNavigation { get; set; }
    }
}
