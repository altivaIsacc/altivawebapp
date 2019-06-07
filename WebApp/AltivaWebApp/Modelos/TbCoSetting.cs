using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbCoSetting
    {
        public long IdSetting { get; set; }
        public long IdTipoSetting { get; set; }
        public long? IdReferencia { get; set; }
        public int IdCuentaContable { get; set; }
        public string TipoReferencia { get; set; }
        public int IdUsuarioCreador { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
