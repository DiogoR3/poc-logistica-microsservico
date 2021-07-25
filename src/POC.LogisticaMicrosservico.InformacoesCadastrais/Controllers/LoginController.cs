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
        public class ViewModelUsuario { public string Login { get; set; } public string Senha { get; set; } }

        public LoginController(UsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public object Login(ViewModelUsuario usuario)
        {
            Usuario usuarioAutenticado = UsuarioRepository.Login(usuario.Login, usuario.Senha);

            if (usuarioAutenticado is null)
                return BadRequest(new { message = "Credenciais inválidas!" });

            string token = TokenService.GenerateToken(usuarioAutenticado, Startup.ChavePrivada);

            return new
            {
                usuarioAutenticado.Login,
                tipo = usuarioAutenticado.Tipo.ToString(),
                token
            };
        }
    }
}
