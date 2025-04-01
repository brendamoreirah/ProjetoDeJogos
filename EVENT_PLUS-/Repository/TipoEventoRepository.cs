using Event_Plus.Context;
using Event_Plus.Domains;
using Event_Plus.Interface;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Repository
{
    public class TipoEventoRepository : ITipoEventoRepository
    {

        private readonly Event_Context _context;
        public TipoEventoRepository(Event_Context context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento tipoBuscados = _context.TipoEvento.Find(id)!;

                if (tipoBuscados != null)
                {
                    tipoBuscados.TituloTipoEvento = tipoEvento.TituloTipoEvento;

                }

                _context.SaveChanges();

            }

            catch (Exception)
            {

                throw;
            }
        }
        

        public TipoEvento BuscarPorId(Guid Id)
        {
            try
            {
                TipoEvento TipoEvento = _context.TipoEvento.Find(Id)!;

                return TipoEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoEvento novoTipoEvento)
        {
            try
            {
                _context.TipoEvento.Add(novoTipoEvento);

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
                TipoEvento eventoBuscado = _context.TipoEvento.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.Remove(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }      
        }

       

        public List<TipoEvento> Listar()
        {
            try
            {
                return _context.TipoEvento
                    .OrderBy(tp => tp.TituloTipoEvento)
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
