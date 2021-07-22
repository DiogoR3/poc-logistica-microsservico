using System;

namespace POC.LogisticaMicrosservico.Repository.Entidades
{
    public class HistoricoLogin
    {
        public long Id { get; set; }
        public int Tentativas { get; set; }
        public DateTime DataHoraSucesso { get; set; }
        public string IPSucesso { get; set; }
        public Usuario Usuario { get; set; }
    }
}
