using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdConfiguracionFiltros
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdContacto { get; set; }
        public int? IdEstado { get; set; }
        public int? IdTipo { get; set; }
        public bool? Estado { get; set; }
    }
}
