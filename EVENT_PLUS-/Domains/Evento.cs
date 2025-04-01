using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Event_Plus.Domains;
using ProjectEventsPlus.Domain;

namespace Event_Plus.Domain
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public Guid EventoId { get; set; }

        [Column(TypeName = ("VARCHAR(50)"))]
        [Required(ErrorMessage = "O nome do evento é obrigatório")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = ("DATE"))]
        [Required(ErrorMessage = "A data do evento é obrigatório")]
        public DateTime? DataEvento { get; set; }

        [Column(TypeName = ("TEXT"))]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string? DescricaoEvento { get; set; }

        [Required(ErrorMessage = "O tipo de evento é obrigatório!")]
        public Guid TipoEventoId { get; set; }
        [ForeignKey("TipoEventoId")]
        public TipoEvento? tipoEvento { get; set; }

        [Required(ErrorMessage = "A instituição é obrigatória")]
        public Guid InstituicaoId { get; set; }
        [ForeignKey("InstituicaoId")]
        public Instituicao? Instituicao { get; set; }
        public Presenca? Presenca { get; set; }

    }
}