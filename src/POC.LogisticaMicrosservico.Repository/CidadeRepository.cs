using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico
{
    public class CidadeRepository : GenericoRepository<Cidade>
    {
        public CidadeRepository(LogisticaDbContext context) : base(context) { }
    }
}