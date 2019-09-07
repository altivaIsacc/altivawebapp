using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdAuditoriaFormaPago
    {
        public long Id { get; set; }
        public long IdAuditoria { get; set; }
        public long IdFormaPago { get; set; }
        public long IdPagoCliente { get; set; }
        public string TipoDocumento { get; set; }
        public long Documento { get; set; }
        public string Moneda { get; set; }
        public double Monto { get; set; }
        public long IdMonedaPago { get; set; }

        public virtual TbFdFormaPago IdFormaPagoNavigation { get; set; }
        public virtual TbFdPagoCliente IdPagoClienteNavigation { get; set; }
    }
}
