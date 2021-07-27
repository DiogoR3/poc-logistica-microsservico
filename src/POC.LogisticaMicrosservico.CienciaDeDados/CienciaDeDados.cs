using System;
using System.Threading.Tasks;

namespace POC.LogisticaMicrosservico.CienciaDeDados
{
    public class CienciaDeDados
    {
        public static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Módulo de Ciência de Dados");
                await Task.Delay(30_000);
            }
        }
    }
}
