using System;
using System.Collections.Generic;

namespace AltivaWebApp.Domains
{
    public partial class TbPrBodega
    {
        public TbPrBodega()
        {
            TbPrAjuste = new HashSet<TbPrAjuste>();
            TbPrInventarioBodega = new HashSet<TbPrInventarioBodega>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool? Produccion { get; set; }
        public bool? Almacenamiento { get; set; }
        public bool? Consignacion { get; set; }
        public bool? SuministrosInternos { get; set; }
        public bool? Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long UsuarioEncargado { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<TbPrAjuste> TbPrAjuste { get; set; }
        public virtual ICollection<TbPrInventarioBodega> TbPrInventarioBodega { get; set; }
    }
}
