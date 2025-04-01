using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{

    [Table("TipoEvento")]
    public class TipoEvento
    {
        [Key]

        public Guid TipoEventoID { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do tipo evento eh obrigatorio!")]

        public string? TituloTipoEvento { get; set; }

    }
}
