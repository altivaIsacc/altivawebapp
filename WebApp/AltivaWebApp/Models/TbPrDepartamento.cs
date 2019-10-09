using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbPrDepartamento
    {
        public TbPrDepartamento()
        {
            TbPrRequisicion = new HashSet<TbPrRequisicion>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Anulado { get; set; }
        public long IdUsuario { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TbPrRequisicion> TbPrRequisicion { get; set; }
    }
}
