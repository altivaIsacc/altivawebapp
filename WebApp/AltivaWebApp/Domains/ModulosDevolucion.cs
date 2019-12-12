using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltivaWebApp.Domains
{
    [Table("tb_FA_Devolucion")]
    public class Devolucion
    {
        [Key]
        public long IdDevolucion { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public float Total { get; set; }
        public long IdContacto { get; set; }
        public long IdVendedor { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Modificacion { get; set; }
        public string Nota { get; set; }
    }
    [Table("tb_FA_DevolucionDetalle")]
    public class DevolucionDetalle
    {
        [Key]
        public long IdDevolucionDetalle { get; set; }
        public long IdDevolucion { get; set; }
        public float Devolver { get; set; }
        public float PrecioUnit { get; set; }
        public float Total { get; set; }
        public long IdInventario { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Modificacion { get; set; }
        public int IdMotivoDevolucion { get; set; }
    }
    [Table("tb_FA_MotivoDevolucion")]
    public class MotivoDevolucion
    {
        [Key]
        public int IdMotivoDevolucion { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Modificacion { get; set; }      
        public string Nota { get; set; }
    }
}


