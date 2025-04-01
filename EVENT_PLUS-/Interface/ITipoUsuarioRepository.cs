using Event_Plus.Domains;

namespace Event_Plus.Interface
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);

        void Deletar(Guid Id);

        List<TipoUsuario> Listar();

        TipoUsuario BuscarPorId(Guid Id);

        void Atualizar(Guid Id, TipoUsuario tipoUsuario);
        
    }
}
