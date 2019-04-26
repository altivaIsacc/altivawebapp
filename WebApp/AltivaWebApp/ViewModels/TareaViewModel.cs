using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class TareaViewModel
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public long? IdUsuario { get; set; }
        public long? IdContacto { get; set; }
        public long? IdEstado { get; set; }
        public long? IdTipo { get; set; }
        public bool? Eliminada { get; set; }
        public DateTime? FechaLimite { get; set; }
        public string Descripcion { get; set; }
        public double? DiasEstimados { get; set; }
        public double? DiasReales { get; set; }
        public double? CostoEstimado { get; set; }
        public double? CostoReal { get; set; }
        public bool? Cobrado { get; set; }
        public double? MontoCobrad { get; set; }


    }
}
