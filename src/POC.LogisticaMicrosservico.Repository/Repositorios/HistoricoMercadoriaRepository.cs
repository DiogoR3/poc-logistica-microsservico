using Microsoft.EntityFrameworkCore;
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
            return from historico in Context.HistoricoMercadoria.Include(h => h.Armazenamento).Include(h => h.Mercadoria)
                   where historico.Mercadoria.Id == idMercadoria
                   orderby historico.DataHora
                   select historico;
        }
    }
}