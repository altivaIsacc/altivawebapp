using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSeMoneda
    {
        public TbSeMoneda()
        {
            TbSeHistorialMoneda = new HashSet<TbSeHistorialMoneda>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activa { get; set; }
        public double ValorCompra { get; set; }
        public double ValorVenta { get; set; }
        public string Simbolo { get; set; }

        public virtual ICollection<TbSeHistorialMoneda> TbSeHistorialMoneda { get; set; }
    }
}
