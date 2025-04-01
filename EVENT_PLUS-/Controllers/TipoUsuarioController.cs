using Event_Plus.Domains;
using Event_Plus.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace projeto_event_plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuariosController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TiposUsuariosController(ITipoUsuarioRepository tiposUsuariosRepository)
        {
            _tipoUsuarioRepository = tiposUsuariosRepository;
        }
        //cadastrar
        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);
                return StatusCode(201, tipoUsuario);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

        //deletar
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //listar
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoUsuario> listaDosUsuarios = _tipoUsuarioRepository.Listar();
                return Ok(listaDosUsuarios);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //buscar por id 
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoUsuario tiposUsuariosBuscado = _tipoUsuarioRepository.BuscarPorId(id);
                return Ok(tiposUsuariosBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //atualizar 
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoUsuario tiposUsuarios)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tiposUsuarios);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}