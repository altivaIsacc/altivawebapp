using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbGeEmpresa
    {
        public TbGeEmpresa()
        {
            TbSeBitacora = new HashSet<TbSeBitacora>();
            TbSeEmpresaUsuario = new HashSet<TbSeEmpresaUsuario>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Bd { get; set; }
        public bool Estado { get; set; }
        public string Correo { get; set; }
        public string CedJuridica { get; set; }
        public string Direccion { get; set; }
        public long IdGrupoEmpresarial { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string Foto { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }

        public virtual TbGeGrupoEmpresarial IdGrupoEmpresarialNavigation { get; set; }
        public virtual ICollection<TbSeBitacora> TbSeBitacora { get; set; }
        public virtual ICollection<TbSeEmpresaUsuario> TbSeEmpresaUsuario { get; set; }
    }
}
