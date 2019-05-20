using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdPagoComision
    {
        public TbFdPagoComision()
        {
            TbFdReservacion = new HashSet<TbFdReservacion>();
        }

        public long Id { get; set; }
        public long IdCliente { get; set; }
        public DateTime FechaPagoCom { get; set; }
        public double Monto { get; set; }

        public virtual TbFdCliente IdClienteNavigation { get; set; }
        public virtual ICollection<TbFdReservacion> TbFdReservacion { get; set; }
    }
}
