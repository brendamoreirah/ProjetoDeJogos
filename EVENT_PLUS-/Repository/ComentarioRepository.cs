using Event_Plus.Context;
using Event_Plus.Domain;
using Event_Plus.Interface;
using Microsoft.Extensions.Logging;

namespace Event_.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly Event_Context _context;

        public ComentarioRepository(Event_Context context)
        {
            _context = context;
        }


        public void Deletar(Guid id)
        {
            try
            {
                Comentario  comentarioEventoBuscado = _context.Comentario.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.Comentario.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        public List<Comentario> Listar(Guid id)
        {
            try
            {
                return _context.Comentario
                    .Select(c => new Comentario
                    {
                        ComentarioEventoId = c.ComentarioEventoId,
                        Descricao = c.Descricao,
                        ExibirComentario = c.ExibirComentario,
                        UsuarioId = c.UsuarioId,
                        EventoId = c.EventoId,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.EventoId == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public List<Comentario> ListarSomenteExibe(Guid id)
        {
            try
            {
                return _context.Comentario
                    .Select(c => new Comentario
                    {
                        ComentarioEventoId = c.ComentarioEventoId,
                        Descricao = c.Descricao,
                        ExibirComentario = c.ExibirComentario,
                        UsuarioId = c.UsuarioId,
                        EventoId = c.EventoId,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.ExibirComentario == true && c.EventoId == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Cadastrar(Comentario comentarioEvento)
        {
            try
            {
                // Assign a new Guid to ComentarioEventoId
                comentarioEvento.ComentarioEventoId = Guid.NewGuid();

                // Add the comentarioEvento object to the context
                _context.Comentario.Add(comentarioEvento);

                // Save changes to the database
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Comentario BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId)
        {
            try
            {
                return _context.Comentario
                    .Select(c => new Comentario
                    {
                        ComentarioEventoId = c.ComentarioEventoId,
                        Descricao = c.Descricao,
                        ExibirComentario = c.ExibirComentario,
                        UsuarioId = c.UsuarioId,
                        EventoId = c.EventoId,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.UsuarioId == UsuarioId && c.EventoId == EventoId)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}



     
   
    