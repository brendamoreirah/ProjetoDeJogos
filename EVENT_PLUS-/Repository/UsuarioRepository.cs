using Event_Plus.Context;
using Event_Plus.Domain;
using Event_Plus.Domains;
using Event_Plus.Interface;
using Event_Plus.Utils;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly Event_Context _context;

    public UsuarioRepository(Event_Context context)
    {
        _context = context;
    }
    public List<Usuario> Listar()
    {
        return _context.Usuario.ToList();
    }

    public Usuario BuscarPorId(Guid id)
    {

        try
        {
            Usuario usuarioBuscado = _context.Usuario
                .Select(u => new Usuario
                {
                    UsuarioId = u.UsuarioId,
                    NomeUsuario = u.NomeUsuario,
                    EmailUsuario = u.EmailUsuario,
                    SenhaUsuario= u.SenhaUsuario,

                    TipoUsuario = new TipoUsuario
                    {
                        TipoUsuarioId = u.TipoUsuarioId!.TipoUsuarioId,
                        TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                    }

                }).FirstOrDefault(u => u.IdUsuario == id)!;

            if (usuarioBuscado != null)
            {
                return usuarioBuscado;

            }
            return null!;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Cadastrar(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Usuario BuscarPoEmaileSenha(string email, string senha)
    {
        throw new NotImplementedException();
    }
}


public void Atualizar(Guid id, Usuario UsuarioAtualizado)
    {
    Usuario UsuarioBuscado = _context.Usuario.Find(id)!;

    if (UsuarioBuscado != null)
    {
        UsuarioBuscado.NomeUsuario = UsuarioAtualizado.NomeUsuario;
        UsuarioBuscado.EmailUsuario = UsuarioAtualizado.EmailUsuario;
        UsuarioBuscado.SenhaUsuario = UsuarioAtualizado.SenhaUsuario;
        UsuarioBuscado.TipoUsuarioId = UsuarioAtualizado.TipoUsuarioId;
    }
    _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        Usuario usuarioBuscado = _context.Usuario.Find(id)!;
        if (usuarioBuscado != null)
        {
            _context.Usuario.Remove(usuarioBuscado);
            _context.SaveChanges();
        }
    }



    public Usuario BuscarPorEmailESenha(string email, string senha)
    {
        try
        {
            Usuario usuarioBuscado = _context.Usuario
                .Select(u => new Usuario
                {
                    UsuarioId = u.UsuarioId,
                    NomeUsuario = u.NomeUsuario,
                    EmailUsuario = u.EmailUsuario,
                    SenhaUsuario = u.SenhaUsuario,

                    TipoUsuarioId = new TipoUsuario
                    {
                        TipoUsuarioId = u.TipoUsuarioId,
                        TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                    }
                }).FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null)
            {
                bool confere = criptografia.CompararHash(senha, usuarioBuscado.SenhaUsuario!);

                if (confere)
                {
                    return usuarioBuscado!;
                }
            }
            return null!;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

