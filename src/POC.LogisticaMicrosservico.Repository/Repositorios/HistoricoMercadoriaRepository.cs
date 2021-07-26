using POC.LogisticaMicrosservico.Repository.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class HistoricoMercadoriaRepository : GenericoRepository<HistoricoMercadoria>
    {
        public HistoricoMercadoriaRepository(LogisticaDbContext context) : base(context) { }

        public IEnumerable<HistoricoMercadoria> ObterHistorico(string idMercadoria)
        {
            return Find(x => x.Mercadoria.Id == idMercadoria).OrderBy(x => x.DataHora);
        }
    }
}