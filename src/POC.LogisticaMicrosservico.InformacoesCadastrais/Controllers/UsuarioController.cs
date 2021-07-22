using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POC.LogisticaMicrosservico.Repositorios;
using POC.LogisticaMicrosservico.Repository.Entidades;
using System.Collections.Generic;

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
        [Route("ListarUsuarios")]
        [Authorize(Roles = "Administrador")]
        public IEnumerable<Usuario> ListarUsuarios()
        {
            return UsuarioRepository.ObterTodos();
        }
    }
}
