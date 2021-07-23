using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using POC.LogisticaMicrosservico.Web.Services;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace POC.LogisticaMicrosservico.Web.Controllers
{
    [ApiController]
    [Route("api")]
    public class DefaultController : ControllerBase
    {
        public InformacoesCadastraisService InformacoesCadastraisService { get; set; }
        public ServicosAoClienteService ServicosAoClienteService { get; set; }
        public class Usuario { public string Login { get; set; } public string Senha { get; set; } }

        public DefaultController(InformacoesCadastraisService informacoesCadastraisService, ServicosAoClienteService servicosAoClienteService)
        {
            InformacoesCadastraisService = informacoesCadastraisService;
            ServicosAoClienteService = servicosAoClienteService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<JsonResult> Login(Usuario usuario)
        {
            var resposta = await InformacoesCadastraisService.Login(usuario.Login, usuario.Senha);
            Response.StatusCode = (int)resposta.Item1;
            return Deserialize(resposta.Item2);
        }

        [HttpGet]
        [Route("ListarUsuarios")]
        public async Task<JsonResult> ListarUsuarios()
        {
            var resposta = await InformacoesCadastraisService.TokenAutorizacao(CabecalhoAutorizacao()).ListarUsuarios();
            Response.StatusCode = (int)resposta.Item1;
            return Deserialize(resposta.Item2);
        }

        [HttpGet]
        [Route("ListarAtendimentos/{id}")]
        public async Task<JsonResult> ListarAtendimentos(string id)
        {
            var resposta = await ServicosAoClienteService.TokenAutorizacao(CabecalhoAutorizacao()).ListarAtendimentos(id);
            Response.StatusCode = (int)resposta.Item1;
            return Deserialize(resposta.Item2);
        }

        [HttpGet]
        [Route("ObterHistoricoMercadoria/{id}")]
        public async Task<JsonResult> ObterHistoricoMercadoria(string id)
        {
            var resposta = await ServicosAoClienteService.TokenAutorizacao(CabecalhoAutorizacao()).ObterHistoricoMercadoria(id);
            Response.StatusCode = (int)resposta.Item1;
            return Deserialize(resposta.Item2);
        }

        private string CabecalhoAutorizacao()
        {
            Request.Headers.TryGetValue("Authorization", out StringValues CabecalhoAutorizacao);
            return CabecalhoAutorizacao;
        }

        private static JsonResult Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
                return new JsonResult(null);

            return new JsonResult(JsonSerializer.Deserialize<dynamic>(json));
        }
    }
}
