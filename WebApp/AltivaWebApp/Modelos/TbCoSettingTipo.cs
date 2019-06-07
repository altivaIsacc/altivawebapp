using System;
using System.Collections.Generic;

namespace AltivaWebApp.Modelos
{
    public partial class TbCoSettingTipo
    {
        public long IdTipoSetting { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string TipoCuentaContable { get; set; }
        public string Observacion { get; set; }
    }
}
