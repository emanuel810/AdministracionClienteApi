using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace administracionCliente_Api.Entities
{
    [Table("Empresa")]
    public class EmpresaEntity
    {
        [Key]
        public int empresaNumero { get; set; }
        public string nombre { get; set; }
        public string pais { get; set; }
    }
}
