using Event_Plus.Controllers;
using Event_Plus.Domain;
using ProjectEventsPlus.Domain;

namespace Event_Plus.Interface
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentarioEvento);

        void Deletar(Guid id);

       List<Comentario>Listar(Guid Id);

        Comentario BuscarPorIdUsuario(Guid UsuarioId, Guid IdEvento);
        
    }
}
