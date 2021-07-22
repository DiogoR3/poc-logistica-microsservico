using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class AtendimentoRepository : GenericoRepository<Atendimento>
    {
        public AtendimentoRepository(LogisticaDbContext context) : base(context) { }
    }
}