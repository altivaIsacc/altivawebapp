﻿using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbReDesbloqueoFiguraSalon
    {
        public long Id { get; set; }
        public long IdFiguraSalon { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
    }
}
