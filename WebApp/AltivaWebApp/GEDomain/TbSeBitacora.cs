using System;
using System.Collections.Generic;

namespace AltivaWebApp.GEDomain
{
    public partial class TbSeBitacora
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public long? IdReferencia { get; set; }
        public string TipoReferencia { get; set; }
        public long? IdEmpresa { get; set; }

        public virtual TbGeEmpresa IdEmpresaNavigation { get; set; }
        public virtual TbSeUsuario IdUsuarioNavigation { get; set; }
    }
}
