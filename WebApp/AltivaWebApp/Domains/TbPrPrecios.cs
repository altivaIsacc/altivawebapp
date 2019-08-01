using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrPrecios
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Anulado { get; set; }
        public long IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
