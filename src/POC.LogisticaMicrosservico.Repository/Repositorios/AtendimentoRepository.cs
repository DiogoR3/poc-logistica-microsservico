using POC.LogisticaMicrosservico.Repository.Entidades;
using System.Collections.Generic;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class AtendimentoRepository : GenericoRepository<Atendimento>
    {
        public AtendimentoRepository(LogisticaDbContext context) : base(context) { }

        public IEnumerable<Atendimento> ObterAtendimento(string chamado)
        {
            return Find(x => x.Chamado == chamado);
        }
    }
}
