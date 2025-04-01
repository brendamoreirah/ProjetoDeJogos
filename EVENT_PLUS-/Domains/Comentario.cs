using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Event_Plus.Domains;
using Microsoft.EntityFrameworkCore;


namespace Event_Plus.Domain
{
    [Table("Comentario")]
    [Index(nameof(ExibirComentario), IsUnique = true)]
    public class Comentario
    {
        [Key]
        public Guid ComentarioEventoId { get; set; }
        [Column(TypeName = ("TEXT"))]
        [Required(ErrorMessage = "O comentário é obrigatório")]
        public string? ComentarioEvento { get; set; }

        [Column(TypeName = ("BIT"))]
        [Required(ErrorMessage = "A resposta é necessária!")]
        public bool? ExibirComentario { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Descrição do comentário obrigatório!")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Usuário obrigatório")]
        public Guid UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "O evento é obrigatório")]
        public Guid EventoId { get; set; }
        [ForeignKey("EventoId")]
        public Evento? Evento { get; set; }
    }
}
