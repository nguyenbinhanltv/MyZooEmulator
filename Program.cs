using System;
using System.Runtime.InteropServices;
using System.Text;
using MyZooEmulator.Engines;
using MyZooEmulator.Repo;

namespace MyZooEmulator
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleOutputCP(uint wCodePageID);
        
        static void Main(string[] args)
        {
            //Use VietNamese
            SetConsoleOutputCP(65001);
            Console.OutputEncoding = Encoding.UTF8;
            
            //Change color message
            Console.ForegroundColor = ConsoleColor.Red;
            
            // Create zooEmulator
            var zoo = new ZooRepo();
            zoo.AddAnimalsForDebug();

            // Create God of death
            var Anubis = new GodOfDeath();
            Anubis.SetWatchPeriod(5000);
            Anubis.WatchFor(zoo);
            Anubis.WakeUp();

            // Create menu and app logic
            var engine = new Engine(zoo);
            // Run app logic
            engine.Run();           
        }
    }
}