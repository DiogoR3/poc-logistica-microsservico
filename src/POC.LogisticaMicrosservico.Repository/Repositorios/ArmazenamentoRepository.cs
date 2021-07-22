using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class ArmazenamentoRepository : GenericoRepository<Armazenamento>
    {
        public ArmazenamentoRepository(LogisticaDbContext context) : base(context) { }
    }
}