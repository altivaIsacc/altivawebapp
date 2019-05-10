using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdTareaTipo
    {
        public TbFdTareaTipo()
        {
            TbFdTarea = new HashSet<TbFdTarea>();
            this.Activo = true;
        }

        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Color { get; set; }
        public bool? ControlaFechaLimite { get; set; }
        public double? DiasFechaLimite { get; set; }
        public bool? EsTipoDefecto { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<TbFdTarea> TbFdTarea { get; set; }
    }
}
