using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbFdAuditoriaNocturna
    {
        public long Id { get; set; }
        public DateTime Dia { get; set; }
        public long IdUsuario { get; set; }
        public DateTime Creacion { get; set; }
        public bool Inactivo { get; set; }
    }
}
