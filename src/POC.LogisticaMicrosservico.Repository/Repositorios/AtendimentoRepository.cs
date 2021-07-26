using Microsoft.EntityFrameworkCore;
using POC.LogisticaMicrosservico.Repository.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class AtendimentoRepository : GenericoRepository<Atendimento>
    {
        public AtendimentoRepository(LogisticaDbContext context) : base(context) { }

        public IEnumerable<Atendimento> ObterAtendimento(string chamado)
        {
            return from atendimentos in Context.Atendimento.Include(m => m.Mercadoria)
                   where atendimentos.Chamado == chamado
                   orderby atendimentos.Id
                   select atendimentos;
        }
    }
}
