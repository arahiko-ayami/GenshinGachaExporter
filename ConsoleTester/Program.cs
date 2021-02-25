using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exporter;

using Models.GachaLogModels;

namespace ConsoleTester
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Title = "Genshin Impact Gacha Log Exporter by @Arahiko";
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please don't forget to: ");
            Console.WriteLine("     1. Launch the game, open the gacha history page");
            Console.WriteLine("     2. Close the game before launch this application");
            Console.WriteLine("If you have done this, you're ready, press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            await GetData.getData();
        }
    }
}