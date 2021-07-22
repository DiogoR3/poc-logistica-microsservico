namespace POC.LogisticaMicrosservico.Repository.Entidades
{
    public class Endereco
    {
        public long Id { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
    }
}
