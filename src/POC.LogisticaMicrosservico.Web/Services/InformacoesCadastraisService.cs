using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico.Web.Services
{
    public class InformacoesCadastraisService
    {
        private readonly string Hostname = Environment.GetEnvironmentVariable("HOSTNAME_INFORMACOESCADASTRAIS");
        private string Autorizacao { get; set; }

        public InformacoesCadastraisService TokenAutorizacao(string cabecalhoAutorizacao)
        {
            Autorizacao = cabecalhoAutorizacao;
            return this;
        }

        public async Task<(HttpStatusCode, string)> Login(string login, string senha)
        {
            return await HttpService.HttpRequestAsync($"{Hostname}/Login", HttpMethod.Post, null, new { login, senha });
        }

        public async Task<(HttpStatusCode, string)> ListarUsuarios()
        {
            return await HttpService.HttpRequestAsync($"{Hostname}/Usuario", HttpMethod.Get, Autorizacao);
        }                                     
    }
}
