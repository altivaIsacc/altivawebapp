using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFaCajaCierre
    {
        public TbFaCajaCierre()
        {
            TbFaCajaArqueo = new HashSet<TbFaCajaArqueo>();
        }

        public long IdCajaCierre { get; set; }
        public long? IdCaja { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }
        public long? IdMoneda { get; set; }
        public double? Efectivo { get; set; }
        public double? EfectivoReal { get; set; }
        public double? Bancos { get; set; }
        public double? BancoReal { get; set; }
        public double? Tarjeta { get; set; }
        public double? TarjetaReal { get; set; }
        public double? Entradas { get; set; }
        public double? Salidas { get; set; }

        public virtual TbFaCaja IdCajaNavigation { get; set; }
        public virtual ICollection<TbFaCajaArqueo> TbFaCajaArqueo { get; set; }
    }
}
