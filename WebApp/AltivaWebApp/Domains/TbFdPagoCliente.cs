using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdPagoCliente
    {
        public TbFdPagoCliente()
        {
            TbFdAuditoriaFormaPago = new HashSet<TbFdAuditoriaFormaPago>();
            TbFdCuentaEnCasaPagoCliente = new HashSet<TbFdCuentaEnCasaPagoCliente>();
            TbFdDesgloceReserva = new HashSet<TbFdDesgloceReserva>();
            TbFdFormaPago = new HashSet<TbFdFormaPago>();
            TbFdNotaDebitoPagoDetalle = new HashSet<TbFdNotaDebitoPagoDetalle>();
            TbFdPagoDetalleFactura = new HashSet<TbFdPagoDetalleFactura>();
        }

        public long Id { get; set; }
        public string ReciboManual { get; set; }
        public DateTime FechaPago { get; set; }
        public long IdCliente { get; set; }
        public int IdMoneda { get; set; }
        public bool Anulado { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double Total { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }

        public virtual TbFdCliente IdClienteNavigation { get; set; }
        public virtual ICollection<TbFdAuditoriaFormaPago> TbFdAuditoriaFormaPago { get; set; }
        public virtual ICollection<TbFdCuentaEnCasaPagoCliente> TbFdCuentaEnCasaPagoCliente { get; set; }
        public virtual ICollection<TbFdDesgloceReserva> TbFdDesgloceReserva { get; set; }
        public virtual ICollection<TbFdFormaPago> TbFdFormaPago { get; set; }
        public virtual ICollection<TbFdNotaDebitoPagoDetalle> TbFdNotaDebitoPagoDetalle { get; set; }
        public virtual ICollection<TbFdPagoDetalleFactura> TbFdPagoDetalleFactura { get; set; }
    }
}
