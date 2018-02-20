using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Web;

namespace Demo.Cliente
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MakeRequest();

            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }

        private static async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "4904bf8d34dc49d4a671536e76d328c8");

            var uri = "https://apim-demo-fepade.azure-api.net/testcache/api/Demo?" + queryString;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var response = await client.GetAsync(uri);
            stopwatch.Stop();
            var timpo = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Tiempo transcurrido: " + timpo);
        }
    }
}