using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaCajaArqueo
    {
        public long IdCajaArqueo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public int IdMoneda { get; set; }
        public double EfectivoReal { get; set; }
        public double BancoReal { get; set; }
        public double TarjetaReal { get; set; }
        public long IdCaja { get; set; }

        public virtual TbFaCaja IdCajaNavigation { get; set; }
    }
}
