using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class MensajeRecibidoViewModel
    {
        public int Id { get; set; }
        public string UsuarioEmisor { get; set; }
        public string Mensaje { get; set; }
        public int IdMensaje { get; set; }
        public string Estado { get; set; }
        public string tipoReferencia { get; set; }
        public string UsuarioReceptor { get; set; }
        public string ruta { get; set; }
        public long? IdUsuarioReceptor { get; set; }
        public int? IdReceptor { get; set; }

    }
}
