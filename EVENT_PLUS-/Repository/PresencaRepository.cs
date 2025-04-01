using Event_Plus.Context;
using Event_Plus.Domain;
using Event_Plus.Interface;
using ProjectEventsPlus.Domain;


namespace Eventplus_api_senai.Repository
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly Event_Context _context;
        public PresencaRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Presenca presenca)
        {
            try
            {
                Presenca presencaBuscado = _context.Presenca.Find(id)!;
                if (presencaBuscado != null)
                {
                    presencaBuscado.Situacao = presenca.Situacao;
                }
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                Presenca presencaBuscada = _context.Presenca.Find(id)!;
                return presencaBuscada;
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
                Presenca presencaBuscada = _context.Presenca.Find(id)!;
                if (presencaBuscada != null)
                {
                    _context.Presenca.Remove(presencaBuscada);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(Presenca Inscricao)
        {
            try
            {
                _context.Presenca.Add(Inscricao);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Presenca> Listar()
        {
            try
            {
                List<Presenca> listaPresenca = _context.Presenca.ToList();
                return listaPresenca;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Presenca> listar()
        {

            try
            {
                return _context.Presenca
                    .Select(p => new Presenca
                    {
                        PresencaId = p.PresencaId,
                        Situacao = p.Situacao,

                        Evento = new Evento
                        {
                            EventoId = p.EventoId,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            DescricaoEvento = p.Evento.DescricaoEvento,

                            Instituicao = new Instituicao
                            {
                                InstituicaoId = p.Evento.Instituicao!.InstituicaoId,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

       




       

        public List<Presenca> ListarMinhaspresencas(Guid id)
        {
            try
            {
                List<Presenca> listaPresenca = _context.Presenca.Where(p => p.UsuarioId == id).ToList();
                return listaPresenca;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}