using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Domains
{
    public partial class TbCrContactoVisita
    {
     
        public long IdContactoVisita { get; set; }
        public long IdContacto { get; set; }
        public long IdUsuarioCreacion { get; set; }
        public long IdUsuarioModificacion { get; set; }
        public int IdVisitaTipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Observacion { get; set; }
        public string Foto { get; set; }
        public int Estado { get; set; }

        public virtual TbCrVisitaTipo IdVisitaTipoNavigation { get; set; }
      //  public virtual ICollection<TbCrVisitaTipo> TbCrVisitaTipo { get; set; }//s


    }
}
