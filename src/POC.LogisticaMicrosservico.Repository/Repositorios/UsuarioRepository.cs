using POC.LogisticaMicrosservico.Repository.Entidades;
using System;
using System.Linq;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class UsuarioRepository : GenericoRepository<Usuario>
    {
        public UsuarioRepository(LogisticaDbContext context) : base(context) { }

        public Usuario Login(string login, string senha)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
                return null;

            return Find(us => us.Login == login && us.Senha == senha).FirstOrDefault();
        }
    }
}
