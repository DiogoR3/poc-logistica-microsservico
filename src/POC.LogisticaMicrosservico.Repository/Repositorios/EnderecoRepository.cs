using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class EnderecoRepository : GenericoRepository<Endereco>
    {
        public EnderecoRepository(LogisticaDbContext context) : base(context) { }
    }
}