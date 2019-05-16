using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbFdTareaEstado
    {
        public TbFdTareaEstado()
        {
            this.Activo = true;
            TbFdTarea = new HashSet<TbFdTarea>();
        }

        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Color { get; set; }
        public bool? EsDefecto { get; set; }
        public bool? EsInicial { get; set; }
        public bool? EsFinal { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<TbFdTarea> TbFdTarea { get; set; }
    }
}
