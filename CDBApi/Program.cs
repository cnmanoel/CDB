using Microsoft.Owin.Hosting;
using System;

namespace CDBApi
{
    public class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:5050/";

            try
            {
                using (WebApp.Start<Startup>(baseAddress))
                {
                    Console.WriteLine($"Servidor iniciado em {baseAddress}");
                    Console.WriteLine($"Swagger UI disponível em {baseAddress}swagger/ui/index");
                    Console.WriteLine("Pressione qualquer tecla para encerrar...");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao iniciar o servidor: {ex.Message}");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
}