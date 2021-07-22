using POC.LogisticaMicrosservico.Repository.Entidades;

namespace POC.LogisticaMicrosservico
{
    public class UsuarioRepository : GenericoRepository<Usuario>
    {
        public UsuarioRepository(LogisticaDbContext context) : base(context) { }
    }
}