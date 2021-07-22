namespace POC.LogisticaMicrosservico.Repository.Entidades
{
    public class Armazenamento
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public float CapacidadeM2 { get; set; }
        public Endereco Endereco { get; set; }
    }
}
