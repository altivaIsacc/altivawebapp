using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdNotaDetalleFactura
    {
        public long Id { get; set; }
        public long IdFactura { get; set; }
        public double Monto { get; set; }
        public double Aplicado { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double AplicadoNotaCredito { get; set; }
        public long IdNotaCredito { get; set; }

        public virtual TbFdFacturacion IdFacturaNavigation { get; set; }
        public virtual TbFdNotasCredito IdNotaCreditoNavigation { get; set; }
    }
}
