﻿using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbReCortesias
    {
        public int IdCortesias { get; set; }
        public int IdUsuarioCreador { get; set; }
        public int IdUsuarioModificador { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
    }
}
