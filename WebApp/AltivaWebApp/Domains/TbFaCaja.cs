using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaCaja
    {
        public TbFaCaja()
        {
            TbFaCajaAperturaDenominacion = new HashSet<TbFaCajaAperturaDenominacion>();
            TbFaCajaArqueo = new HashSet<TbFaCajaArqueo>();
            TbFaCajaArqueoDenominacion = new HashSet<TbFaCajaArqueoDenominacion>();
            TbFaCajaCierre = new HashSet<TbFaCajaCierre>();
        }

        public long IdCaja { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<TbFaCajaAperturaDenominacion> TbFaCajaAperturaDenominacion { get; set; }
        public virtual ICollection<TbFaCajaArqueo> TbFaCajaArqueo { get; set; }
        public virtual ICollection<TbFaCajaArqueoDenominacion> TbFaCajaArqueoDenominacion { get; set; }
        public virtual ICollection<TbFaCajaCierre> TbFaCajaCierre { get; set; }
    }
}
