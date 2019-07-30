using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbCpCategoriaGasto
    {
        public int Id { get; set; }
        public bool? Tipo { get; set; }
        public string Nombre { get; set; }
        public bool? Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
    }
}
