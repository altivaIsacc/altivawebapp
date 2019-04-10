using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.ViewModels
{
    public class ModuloPerfilViewModel
    {
        public int IdModulo { get; set; }
        public int IdPerfil { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Ejecutar { get; set; }
        public bool Actualizar { get; set; }
        public bool Imprimir { get; set; }
        public bool Insertar { get; set; }
        public bool Eliminar { get; set; }
        public bool Opcion1 { get; set; }
        public bool Opcion2 { get; set; }
        public string Grupo { get; set; }

    }
}
