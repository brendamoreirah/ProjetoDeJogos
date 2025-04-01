using Event_Plus.Domain;
using Event_Plus.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201, usuario);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }


        /// <summary>
        /// EndPoint para Buscar um usuario
        /// </summary>
        /// <param name="id"> id do usuario buscado</param>
        /// <returns>Usuario Buscado</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(Id);

                return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
