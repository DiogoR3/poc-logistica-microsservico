using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POC.LogisticaMicrosservico.Repositorios;
using POC.LogisticaMicrosservico.Repository.Entidades;
using System.Collections.Generic;

namespace POC.LogisticaMicrosservico.ServicosAoCliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtendimentoController : ControllerBase
    {
        public AtendimentoRepository AtendimentoRepository { get; set; }

        public AtendimentoController(AtendimentoRepository atendimentoRepository)
        {
            AtendimentoRepository = atendimentoRepository;
        }

        [HttpGet]
        [Route("{chamado}")]
        [Authorize(Roles = "Administrador,Cliente,Fornecedor")]
        public IEnumerable<Atendimento> ObterAtendimento(string chamado)
        {
            return AtendimentoRepository.ObterAtendimento(chamado);
        }
    }
}
