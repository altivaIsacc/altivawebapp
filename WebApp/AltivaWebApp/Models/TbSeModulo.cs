using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSeModulo
    {
        public TbSeModulo()
        {
            TbSePerfilModulo = new HashSet<TbSePerfilModulo>();
        }

        public long Id { get; set; }
        public string NombreInterno { get; set; }
        public string NombreExterno { get; set; }
        public string Descripcion { get; set; }
        public string NotaOpcion1 { get; set; }
        public string NotaOpcion2 { get; set; }
        public string Grupos { get; set; }

        public virtual ICollection<TbSePerfilModulo> TbSePerfilModulo { get; set; }
    }
}
