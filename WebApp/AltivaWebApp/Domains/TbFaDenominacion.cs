using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaDenominacion
    {
        public TbFaDenominacion()
        {
            TbFaCajaAperturaDenominacion = new HashSet<TbFaCajaAperturaDenominacion>();
            TbFaCajaArqueoDenominacion = new HashSet<TbFaCajaArqueoDenominacion>();
        }

        public long IdDenominaciones { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }
        public int? Estado { get; set; }
        public int? IdMoneda { get; set; }
        public double? Valor { get; set; }
        public int? Tipo { get; set; }

        public virtual ICollection<TbFaCajaAperturaDenominacion> TbFaCajaAperturaDenominacion { get; set; }
        public virtual ICollection<TbFaCajaArqueoDenominacion> TbFaCajaArqueoDenominacion { get; set; }
    }
}
