using Event_Plus.Domain;
using ProjectEventsPlus.Domain;

namespace Event_Plus.Interface
{
    public interface IEventoRepository
    {
        void Cadastrar (Evento novoEvento);

        void Deletar(Guid id);

        List<Evento> Listar();

        List<Evento> ListarPorId(Guid id);

        List<Evento> ProximosEventos();

        Evento BuscarPorId(Guid id);

        void Atualizar(Guid id, Evento evento);
    }
}
