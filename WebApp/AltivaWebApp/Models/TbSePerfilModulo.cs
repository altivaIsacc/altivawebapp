using System;
using System.Collections.Generic;

namespace AltivaWebApp.Models
{
    public partial class TbSePerfilModulo
    {
        public long Id { get; set; }
        public long IdModulo { get; set; }
        public long IdPerfil { get; set; }
        public bool Ejecutar { get; set; }
        public bool Actualizar { get; set; }
        public bool Imprimir { get; set; }
        public bool Insertar { get; set; }
        public bool Eliminar { get; set; }
        public bool Opcion1 { get; set; }
        public bool Opcion2 { get; set; }

        public virtual TbSeModulo IdModuloNavigation { get; set; }
        public virtual TbSePerfil IdPerfilNavigation { get; set; }
    }
}
