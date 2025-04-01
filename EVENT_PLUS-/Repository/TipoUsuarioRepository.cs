using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interface;


namespace EventPlus_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
    
        private readonly Event_Context _context;

        public TipoUsuarioRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;
                return tipoUsuarioBuscado;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _context.TipoUsuario.Add(novoTipoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    _context.TipoUsuario.Remove(tipoUsuarioBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public List<TipoUsuario> Listar()
        {
            try
            {
                List<TipoUsuario> listaDeUsuarios = _context.TipoUsuario.ToList();
                return listaDeUsuarios;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
