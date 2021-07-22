namespace POC.LogisticaMicrosservico.Repository.Entidades
{
    public class Atendimento
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public string Chamado { get; set; }
        public Mercadoria Mercadoria { get; set; }
    }
}
