using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class DenominacionesViewModel
    {
        public long IdDenominaciones { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public long? IdUsuario { get; set; }
        public int? Estado { get; set; }
        public int? IdMoneda { get; set; }
        public double? Valor { get; set; }
        public int? Tipo { get; set; }

    }
}
