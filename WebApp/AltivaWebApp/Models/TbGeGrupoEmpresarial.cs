using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbGeGrupoEmpresarial
    {
        public TbGeGrupoEmpresarial()
        {
            TbGeEmpresa = new HashSet<TbGeEmpresa>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
        public string Foto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public long IdUsuario { get; set; }

        public virtual TbSeUsuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<TbGeEmpresa> TbGeEmpresa { get; set; }
    }
}
