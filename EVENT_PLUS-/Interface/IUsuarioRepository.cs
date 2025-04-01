using Event_Plus.Domain;
using ProjectEventsPlus.Domain;

namespace Event_Plus.Interface
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid Id);

        Usuario BuscarPoEmaileSenha(string email, string senha);   


    }
}
