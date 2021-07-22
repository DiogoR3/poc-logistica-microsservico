using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class CidadeRepository : GenericoRepository<Cidade>
    {
        public CidadeRepository(LogisticaDbContext context) : base(context) { }
    }
}