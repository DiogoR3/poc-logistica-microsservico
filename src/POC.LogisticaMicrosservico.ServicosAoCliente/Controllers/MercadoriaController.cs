using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POC.LogisticaMicrosservico.Repositorios;
using POC.LogisticaMicrosservico.Repository.Entidades;
using System.Collections.Generic;

namespace POC.LogisticaMicrosservico.ServicosAoCliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MercadoriaController : ControllerBase
    {
        public MercadoriaRepository MercadoriaRepository { get; set; }
        public HistoricoMercadoriaRepository HistoricoMercadoriaRepository { get; set; }

        public MercadoriaController(MercadoriaRepository mercadoriaRepository, HistoricoMercadoriaRepository historicoMercadoriaRepository)
        {
            MercadoriaRepository = mercadoriaRepository;
            HistoricoMercadoriaRepository = historicoMercadoriaRepository;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Administrador,Colaborador")]
        public IEnumerable<HistoricoMercadoria> ObterMercadoria(string id)
        {
            return HistoricoMercadoriaRepository.ObterHistorico(id);
        }
    }
}
