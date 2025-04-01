using Event_Plus.Context;
using Event_Plus.Domain;
using Event_Plus.Domains;
using Event_Plus.Interface;
using ProjectEventsPlus.Domain;

public class EventoRepository : IEventoRepository
{
    private readonly Event_Context _context;

    public EventoRepository(Event_Context context)
    {
        _context = context;
    }


    public List<Evento> Listar()
    {
        return _context.Evento.ToList();
    }
    //Desenvolver os metodos que foram
    //criados na minha interface
    // Método para buscar um tipo de evento pelo ID
    public Evento BuscarPorId(Guid id)
    {
        return _context.Evento.Find(id)!;
    }

    // Método para cadastrar um novo tipo de evento
    public void Cadastrar(Evento evento)
    {
        _context.Evento.Add(evento);
        _context.SaveChanges();
    }

    // Método para atualizar um tipo de evento existente
    public void Atualizar(Guid id, Evento eventoAtualizado)
    {
        try
        {
            Evento eventoBuscado = _context.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.DataEvento = eventoAtualizado.DataEvento;
                eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
                eventoBuscado.DescricaoEvento = eventoAtualizado.DescricaoEvento;
                eventoBuscado.TipoEventoId = eventoAtualizado.TipoEventoId;
            }

            _context.Evento.Update(eventoBuscado!);

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
            Evento eventoBuscado = _context.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                _context.Evento.Remove(eventoBuscado);
            }

            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }


    public List<Evento> ListarPorId(Guid id)
    {
        try
        {
            return _context.Evento
                .Select(e => new Evento
                {
                    TipoEventoId = e.TipoEventoId,
                    NomeEvento = e.NomeEvento,
                    DescricaoEvento = e.DescricaoEvento,
                    DataEvento = e.DataEvento,
                    EventoId = e.TipoEventoId,
                    tipoEvento = new TipoEvento
                    {
                        TipoEventoID = e.TipoEventoId,
                        TituloTipoEvento = e.tipoEvento!.TituloTipoEvento
                    },
                    InstituicaoId = e.InstituicaoId,
                    Instituicao = new Instituicao
                    {
                        InstituicaoId = e.InstituicaoId,
                        NomeFantasia = e.Instituicao!.NomeFantasia
                    }
                }).ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Evento> ProximosEventos()
    {

        try
        {
            List<Evento> listarProximoEvento = _context.Evento.Where(e => e.DataEvento > DateTime.Now).OrderBy(e => e.DataEvento).ToList();
            return listarProximoEvento;
        }
        catch (Exception)
        {

            throw;
        }
    }

   
}