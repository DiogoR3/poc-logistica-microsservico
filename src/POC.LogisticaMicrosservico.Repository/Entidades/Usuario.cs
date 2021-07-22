using System;

namespace POC.LogisticaMicrosservico.Repository.Entidades
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string TokenAPI { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Habilitado { get; set; }
        public string Contato { get; set; }
        public TipoUsuario Tipo { get; set; }
    }
}
