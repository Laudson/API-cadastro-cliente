using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace LtjApi.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build()
                .Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
