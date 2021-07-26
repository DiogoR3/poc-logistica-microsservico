using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POC.LogisticaMicrosservico.Repositorios;
using POC.LogisticaMicrosservico.Repository.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.LogisticaMicrosservico.InformacoesCadastrais.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public UsuarioRepository UsuarioRepository { get; set; }

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IEnumerable<Usuario> ListarUsuarios()
        {
            List<Usuario> listaUsuarios = UsuarioRepository.ObterTodos().ToList();

            listaUsuarios.ForEach(us => us.Senha = string.Empty);

            return listaUsuarios;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            Usuario novoUsuario = await UsuarioRepository.Criar(usuario);

            novoUsuario.Senha = string.Empty;

            return novoUsuario;
        }
    }
}
