using System;
using System.Threading.Tasks;

namespace POC.LogisticaMicrosservico.GestaoEEstrategia
{
    public class GestaoEEstrategia
    {
        public static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Módulo de Gestão e Estratégia");
                await Task.Delay(30_000);
            }
        }
    }
}
