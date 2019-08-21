
using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    //creada por lenin
    public partial class TbBaFlujoCategoria
    {
        public long IdCategoriaFlujo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long IdUsuario { get; set; }
        public int IdTipoFlujo { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Estado { get; set; }
    }
}
