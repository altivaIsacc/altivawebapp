using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdFormaPago
    {
        public TbFdFormaPago()
        {
            TbFdAuditoriaFormaPago = new HashSet<TbFdAuditoriaFormaPago>();
        }

        public long Id { get; set; }
        public int IdMoneda { get; set; }
        public string Tipo { get; set; }
        public double Monto { get; set; }
        public string Referencia { get; set; }
        public string IdCuentaBancaria { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdPagoCliente { get; set; }
        public double Conversion { get; set; }
        public double TipoCambioDolar { get; set; }
        public double TipoCambioEuro { get; set; }
        public double TipoCambio { get; set; }
        public long IdAperturaCaja { get; set; }
        public double Vuelto { get; set; }

        public virtual TbFdAperturaCaja IdAperturaCajaNavigation { get; set; }
        public virtual TbFdPagoCliente IdPagoClienteNavigation { get; set; }
        public virtual ICollection<TbFdAuditoriaFormaPago> TbFdAuditoriaFormaPago { get; set; }
    }
}
