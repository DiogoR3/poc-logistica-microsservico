using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico
{
    public class ArmazenamentoRepository : GenericoRepository<Armazenamento>
    {
        public ArmazenamentoRepository(LogisticaDbContext context) : base(context) { }
    }
}