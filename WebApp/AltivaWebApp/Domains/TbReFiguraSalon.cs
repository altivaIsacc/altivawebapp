using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbReFiguraSalon
    {
        public long Id { get; set; }
        public int IdSalon { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public string Categoria { get; set; }
        public string TipoVisual { get; set; }
        public int Largo { get; set; }
        public string Texto { get; set; }
        public string Estado { get; set; }
        public int IdUsuarioUltimaModificacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public int Unir { get; set; }
    }
}
