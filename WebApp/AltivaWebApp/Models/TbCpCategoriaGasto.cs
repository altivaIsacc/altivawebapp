using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbCpCategoriaGasto
    {
        public TbCpCategoriaGasto()
        {
            TbCpComprasDetalleServicio = new HashSet<TbCpComprasDetalleServicio>();
        }

        public int Id { get; set; }
        public bool? Tipo { get; set; }
        public string Nombre { get; set; }
        public bool? Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }

        public virtual ICollection<TbCpComprasDetalleServicio> TbCpComprasDetalleServicio { get; set; }
    }
}
