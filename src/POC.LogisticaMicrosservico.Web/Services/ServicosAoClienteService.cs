using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace POC.LogisticaMicrosservico.Web.Services
{
    public class ServicosAoClienteService
    {
        private readonly string Hostname = Environment.GetEnvironmentVariable("HOSTNAME_SERVICOSAOCLIENTE");
        private string Autorizacao { get; set; }

        public ServicosAoClienteService TokenAutorizacao(string cabecalhoAutorizacao)
        {
            Autorizacao = cabecalhoAutorizacao;
            return this;
        }

        public async Task<(HttpStatusCode, string)> ListarAtendimentos(string id)
        {
            return await HttpService.HttpRequestAsync($"{Hostname}/Atendimento/{id}", HttpMethod.Get, Autorizacao);
        }

        public async Task<(HttpStatusCode, string)> ObterHistoricoMercadoria(string id)
        {
            return await HttpService.HttpRequestAsync($"{Hostname}/Mercadoria/{id}", HttpMethod.Get, Autorizacao);
        }                                     
    }
}
