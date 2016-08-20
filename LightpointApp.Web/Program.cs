using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightpointApp.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUri = ConfigurationManager.AppSettings["BaseUri"];

            Console.WriteLine("Starting web Server...");
            WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
            Console.ReadKey();
        }
    }
}
