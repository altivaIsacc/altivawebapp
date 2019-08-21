using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CajaCierreViewModel
    {
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
    }
}
