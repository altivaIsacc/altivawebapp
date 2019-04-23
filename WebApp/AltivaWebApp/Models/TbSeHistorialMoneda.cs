using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSeHistorialMoneda
    {
        public long Id { get; set; }
        public int CodigoMoneda { get; set; }
        public DateTime Fecha { get; set; }
        public double ValorCompra { get; set; }
        public double ValorVenta { get; set; }
        public long IdUsuario { get; set; }

        public virtual TbSeMoneda CodigoMonedaNavigation { get; set; }
        public virtual TbSeUsuario IdUsuarioNavigation { get; set; }
    }
}
