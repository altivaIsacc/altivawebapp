﻿using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbFdConfiguracionFiltros
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdContacto { get; set; }
        public int? IdEstado { get; set; }
        public int? IdTipo { get; set; }
    }
}
