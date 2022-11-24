using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace administracionCliente_Api.Entities
{
    [Table("Persona")]
    public class PersonaEntity
    {
        [Key]
        public int personaNumero { get; set; }
        public string nombre { get; set; }
        public string cui { get; set; }
        public int sucursalNumero { get; set; }
    }
}
