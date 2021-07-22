using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class HistoricoMercadoriaRepository : GenericoRepository<HistoricoMercadoria>
    {
        public HistoricoMercadoriaRepository(LogisticaDbContext context) : base(context) { }
    }
}