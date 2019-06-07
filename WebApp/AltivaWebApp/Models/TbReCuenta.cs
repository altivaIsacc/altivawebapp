using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbReCuenta
    {
        public long IdCuenta { get; set; }
        public long? IdComanda { get; set; }
        public string NombreCuenta { get; set; }
        public DateTime FechaApertura { get; set; }
        public long IdUsuario { get; set; }
        public bool EstaFacturada { get; set; }
        public bool ExoneradoIv { get; set; }
        public bool ExoneradoIs { get; set; }

        public virtual TbReComanda IdComandaNavigation { get; set; }
    }
}
