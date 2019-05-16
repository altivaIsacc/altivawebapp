using System;
using System.Collections.Generic;

namespace AltivaWebApp.GEDomain
{
    public partial class TbSeUsuario
    {
        public TbSeUsuario()
        {
            TbFdUsuarioCosto = new HashSet<TbFdUsuarioCosto>();
            TbGeGrupoEmpresarial = new HashSet<TbGeGrupoEmpresarial>();
            TbSeBitacora = new HashSet<TbSeBitacora>();
            TbSeEmpresaUsuario = new HashSet<TbSeEmpresaUsuario>();
            TbSeHistorialMoneda = new HashSet<TbSeHistorialMoneda>();
            TbSeMensaje = new HashSet<TbSeMensaje>();
            TbSeMensajeReceptor = new HashSet<TbSeMensajeReceptor>();
            TbSePerfilUsuario = new HashSet<TbSePerfilUsuario>();
            TbSeUsuarioConfiguraion = new HashSet<TbSeUsuarioConfiguraion>();
        }

        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Iniciales { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaMod { get; set; }
        public long? IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Avatar { get; set; }
        public virtual ICollection<TbFdUsuarioCosto> TbFdUsuarioCosto { get; set; }

        public virtual ICollection<TbGeGrupoEmpresarial> TbGeGrupoEmpresarial { get; set; }
        public virtual ICollection<TbSeBitacora> TbSeBitacora { get; set; }
        public virtual ICollection<TbSeEmpresaUsuario> TbSeEmpresaUsuario { get; set; }
        public virtual ICollection<TbSeHistorialMoneda> TbSeHistorialMoneda { get; set; }
        public virtual ICollection<TbSeMensaje> TbSeMensaje { get; set; }
        public virtual ICollection<TbSeMensajeReceptor> TbSeMensajeReceptor { get; set; }
        public virtual ICollection<TbSePerfilUsuario> TbSePerfilUsuario { get; set; }
        public virtual ICollection<TbSeUsuarioConfiguraion> TbSeUsuarioConfiguraion { get; set; }
    }
}
