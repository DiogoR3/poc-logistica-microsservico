using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico
{
    public class HistoricoLoginRepository : GenericoRepository<HistoricoLogin>
    {
        public HistoricoLoginRepository(LogisticaDbContext context) : base(context) { }
    }
}