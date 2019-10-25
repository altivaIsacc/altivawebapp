﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class VisitaTipoViewModel
    {
        public int IdVisitaTipo { get; set; }
        public long IdUsuarioCreacion { get; set; }
        public long IdUsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public int Estado { get; set; }

    }
}