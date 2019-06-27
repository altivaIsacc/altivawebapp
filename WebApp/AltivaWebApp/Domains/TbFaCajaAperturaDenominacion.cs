using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaCajaAperturaDenominacion
    {
        public long IdCajaApertura { get; set; }
        public long? IdCaja { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }
        public long? IdDenominacion { get; set; }
        public double? Cantidad { get; set; }
        public double? Monto { get; set; }

        public virtual TbFaCaja IdCajaNavigation { get; set; }
        public virtual TbFaDenominacion IdDenominacionNavigation { get; set; }
    }
}
