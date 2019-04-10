using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbReUnionFiguraSalon
    {
        public long Id { get; set; }
        public long IdFiguraSalon { get; set; }
        public long IdUsuario { get; set; }
        public DateTime Fechahora { get; set; }
        public string Estado { get; set; }
        public int Color { get; set; }
    }
}
