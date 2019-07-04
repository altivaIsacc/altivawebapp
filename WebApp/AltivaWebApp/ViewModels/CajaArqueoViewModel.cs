using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class CajaArqueoViewModel
    {

        public long IdCajaArqueo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }
        public int? IdMoneda { get; set; }
        public double? EfectivoReal { get; set; }
        public double? BancoReal { get; set; }
        public double? TarjetaReal { get; set; }
        public long? IdCaja { get; set; }
    }
}
