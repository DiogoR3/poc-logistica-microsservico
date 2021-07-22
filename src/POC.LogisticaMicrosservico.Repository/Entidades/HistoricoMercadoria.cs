using System;

namespace POC.LogisticaMicrosservico.Repository.Entidades
{
    public class HistoricoMercadoria
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public Armazenamento Armazenamento { get; set; }
        public DateTime DataHora { get; set; }
        public Mercadoria Mercadoria { get; set; }
    }
}
