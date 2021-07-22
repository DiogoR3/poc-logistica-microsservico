using System;

namespace POC.LogisticaMicrosservico.Repository.Entidades
{
    public class Mercadoria
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public float Frete { get; set; }
        public Endereco Remetente { get; set; }
        public Endereco Destinatario { get; set; }
        public bool Entregue { get; set; } = false;
        public DateTime DataEntrada { get; set; }
        public Usuario Cliente { get; set; }
    }
}
