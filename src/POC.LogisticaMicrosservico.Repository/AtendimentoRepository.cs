using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico
{
    public class AtendimentoRepository : GenericoRepository<Atendimento>
    {
        public AtendimentoRepository(LogisticaDbContext context) : base(context) { }
    }
}