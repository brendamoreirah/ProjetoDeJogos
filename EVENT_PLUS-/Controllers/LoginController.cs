using Api_Event.DTOS;
using Event_Plus.Domain;
using Event_Plus.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Event_Plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPoEmaileSenha(loginDTO.Email!, loginDTO.Senha!);
                if (usuarioBuscado == null)
                {
                    return NotFound("Usuario não encontrado, email ou senha inválidos");
                }



                //caso o usuario seja encontrado, prossegue para a criacao do token
                // 1 PASSO - Definir as Clains() que serao fornecidos no token
                var claims = new[]
                {
                     new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.UsuarioId.ToString()),
                     new Claim (JwtRegisteredClaimNames.Email, usuarioBuscado.EmailUsuario!),
                     new Claim (JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario!),
                     new Claim("Tipo do usuario", usuarioBuscado.TipoUsuarioId.ToString()!),


                    //podemos definir uma claim personalizada
                    new Claim("Nome da Claim", "Valor da Claim")
                };

                //2 passo - definir  a chave de acesseso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventos-chaves-autentificacao-webapi-dev"));

                // 3 passo - Definir as credenciais do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //2 paaso - gerar o token
                var token = new JwtSecurityToken
                    (
                       //emissor do token
                       issuer: "Event_Plus",

                       //destinatario do token
                       audience: "Event_Plus",

                        //dados definidos nas claims
                        claims: claims,

                       //tempo de expiracao do token
                       expires: DateTime.Now.AddMinutes(5),

                       //credenciais do token
                       signingCredentials: creds
                    );

                return Ok(
                      new
                      {
                          token = new JwtSecurityTokenHandler().WriteToken(token)
                      }
                    );
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
    

