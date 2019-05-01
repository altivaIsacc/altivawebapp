using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdTarea
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public long? IdUsuario { get; set; }
        public long IdContacto { get; set; }
        public long? IdEstado { get; set; }
        public long? IdTipo { get; set; }
        public bool? Eliminada { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaLimite { get; set; }
        public string Descripcion { get; set; }
        public double? DiasEstimados { get; set; }
        public double? DiasReales { get; set; }
        public double? CostoEstimado { get; set; }
        public double? CostoReal { get; set; }
        public bool? Cobrado { get; set; }
        public double? MontoCobrad { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public long Posicion { get; set; }

        public virtual TbCrContacto IdContactoNavigation { get; set; }
        public virtual TbFdTareaEstado IdEstadoNavigation { get; set; }
        public virtual TbFdTareaTipo IdTipoNavigation { get; set; }
    }
}
