using POC.LogisticaMicrosservico.Repository.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POC.LogisticaMicrosservico.Repositorios
{
    public class UsuarioRepository : GenericoRepository<Usuario>
    {
        public UsuarioRepository(LogisticaDbContext context) : base(context) { }

        public Usuario Login(string login, string senha)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
                return null;


            IEnumerable<Usuario> usuarios = Find(us => us.Login == login && us.Senha == senha);
            return usuarios.Where(us => us.Senha == senha).FirstOrDefault();
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return GetAll();
        }

        public async Task<Usuario> Criar(Usuario usuario)
        {
            Usuario novoUsuario = new()
            {
                Nome = usuario.Nome,
                Login = usuario.Login,
                Senha = usuario.Senha,
                TokenAPI = Guid.NewGuid().ToString(),
                DataCriacao = DateTime.Now,
                Habilitado = true,
                Contato = usuario.Contato,
                Tipo = usuario.Tipo
            };

            await AddAsync(novoUsuario);
            await SaveChangesAsync(CancellationToken.None);

            return novoUsuario;
        }
    }
}
