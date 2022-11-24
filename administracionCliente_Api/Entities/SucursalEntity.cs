using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace administracionCliente_Api.Entities
{
    [Table("Sucursal")]
    public class SucursalEntity
    {
        [Key]
        public int sucursalNumero { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int empresaNumero { get; set; }
    }
}
