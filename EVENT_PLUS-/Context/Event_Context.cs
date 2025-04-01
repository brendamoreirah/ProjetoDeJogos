using Event_Plus.Domain; // Namespace correto
using Event_Plus.Domains;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Context
{
    public class Event_Context : DbContext
    {
        // Construtor padrão
        public Event_Context() { }

        // Construtor com DbContextOptions
        public Event_Context(DbContextOptions<Event_Context> options) : base(options) { }

        // Definições das tabelas (DbSet)
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Presenca> Presenca { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        // Configuração da string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Substitua "Eventos" pelo nome correto do banco de dados
                optionsBuilder.UseSqlServer("Server=NOTE32-S28\\SQLEXPRESS; Database=Eventos; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");
            }
        }
    }
}
