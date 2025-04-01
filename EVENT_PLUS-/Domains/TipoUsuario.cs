using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{

    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public Guid TipoUsuarioId { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O tipo  do usuario eh obrigatorioo!")]
        public string? TituloTipoUsuario { get; set; }
    }
}
