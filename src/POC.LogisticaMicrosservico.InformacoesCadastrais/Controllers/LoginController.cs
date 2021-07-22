using Microsoft.AspNetCore.Mvc;
using POC.LogisticaMicrosservico.InformacoesCadastrais.Services;
using POC.LogisticaMicrosservico.Repositorios;
using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico.InformacoesCadastrais.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public UsuarioRepository UsuarioRepository { get; set; }

        public LoginController(UsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public object Login(string login, string senha)
        {
            Usuario usuarioAutenticado = UsuarioRepository.Login(login, senha);

            if (usuarioAutenticado is null)
                return BadRequest(new { message = "Credenciais inválidas!" });

            string token = TokenService.GenerateToken(usuarioAutenticado, Startup.ChavePrivada);

            usuarioAutenticado.Senha = string.Empty;

            return new
            {
                usuarioAutenticado.Login,
                token
            };
        }
    }
}
