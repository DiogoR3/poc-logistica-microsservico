using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class EstadoRepository : GenericoRepository<Estado>
    {
        public EstadoRepository(LogisticaDbContext context) : base(context) { }
    }
}