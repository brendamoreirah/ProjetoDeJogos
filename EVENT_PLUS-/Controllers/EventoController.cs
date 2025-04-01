
using Event_Plus.Domain;
using Event_Plus.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }


        //Metodo Listar por Id 
        [HttpGet("ListarPorId/{id}")]
        public IActionResult GetByEvento(Guid id)
        {
            try
            {
                List<Evento> listarEventoId = _eventoRepository.Listar();

                return Ok(listarEventoId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Metodo Cadastrar
        [HttpPost]
        public IActionResult Post(Evento novoEvento)
        {
            try
            {
                _eventoRepository.Cadastrar(novoEvento);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Metodo Buscar
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);
                return Ok(eventoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }

        //MetodoAtualizar
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Evento novoevento)
        {
            try
            {
                _eventoRepository.Atualizar(id, novoevento);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
