using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltivaWebApp.Domains
{
    [Table("tb_PR_TipoAjusteInventario")]
    public class tbPRTipoAjusteInventario
    {
        [Key]
        public long IdTipoAjusteInventario { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuarioMod { get; set; }
        public DateTime FechaCrea { get; set; }
        public DateTime FechaMod { get; set; }

    }
}
