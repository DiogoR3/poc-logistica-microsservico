using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico
{
    public class MercadoriaRepository : GenericoRepository<Mercadoria>
    {
        public MercadoriaRepository(LogisticaDbContext context) : base(context) { }
    }
}