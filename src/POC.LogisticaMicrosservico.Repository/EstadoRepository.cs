using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico
{
    public class EstadoRepository : GenericoRepository<Estado>
    {
        public EstadoRepository(LogisticaDbContext context) : base(context) { }
    }
}