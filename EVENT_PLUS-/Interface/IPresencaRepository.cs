using Event_Plus.Domain;
using ProjectEventsPlus.Domain;

namespace Event_Plus.Interface
{
    public interface IPresencaRepository
    {

        void Inscrever(Presenca incricao);
        void Deletar(Guid id);
        List<Presenca> Listar();
        Presenca BuscarPorId(Guid id);
        void Atualizar(Guid id, Presenca presencaEvento);
        List<Presenca> ListarMinhaspresencas(Guid id);
    }
}
