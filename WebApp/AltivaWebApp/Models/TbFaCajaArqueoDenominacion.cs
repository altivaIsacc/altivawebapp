using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFaCajaArqueoDenominacion
    {
        public long IdCajaArqueoDenominacion { get; set; }
        public long IdCaja { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public long IdDenominacion { get; set; }
        public double Cantidad { get; set; }
        public double Monto { get; set; }

        public virtual TbFaCaja IdCajaNavigation { get; set; }
        public virtual TbFaDenominacion IdDenominacionNavigation { get; set; }
    }
}
