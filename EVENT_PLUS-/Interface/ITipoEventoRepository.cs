using Event_Plus.Domains;

namespace Event_Plus.Interface
{
    public interface ITipoEventoRepository
    {
        void Cadastrar(TipoEvento tipoEvento);

        void Deletar(Guid id);

        List<TipoEvento> Listar();

        TipoEvento BuscarPorId(Guid Id);

        void Atualizar(Guid id, TipoEvento tipoEvento);
    }
}
