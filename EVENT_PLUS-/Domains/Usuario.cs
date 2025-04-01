using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Event_Plus.Domains;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Domain
{
    [Table("Usuario")]
    [Index(nameof(EmailUsuario), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid UsuarioId { get; set; }

        [Column(TypeName = ("VARCHAR(50)"))]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? NomeUsuario { get; set; }

        [Column(TypeName = ("VARCHAR(120)"))]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? EmailUsuario { get; set; }

        [Column(TypeName = ("VARCHAR(60)"))]
        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 a 30 caracteres.")]
        public string? SenhaUsuario { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório!")]
        public Guid TipoUsuarioId { get; set; }
        [ForeignKey("TipoUsuarioId")]
        public TipoUsuario? tipoUsuario { get; set; }
    }
}

