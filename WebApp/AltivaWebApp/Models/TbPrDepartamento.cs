using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrDepartamento
    {
        public TbPrDepartamento()
        {
            TbPrRequisiciones = new HashSet<TbPrRequisiciones>();
        }

        public long IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public bool Inactivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }

        public virtual ICollection<TbPrRequisiciones> TbPrRequisiciones { get; set; }
    }
}
