using System;
using System.Runtime.InteropServices;
using System.Text;
using MyZooEmulator.Engines;
using MyZooEmulator.Repo;

namespace MyZooEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Use VietNamese
            Console.OutputEncoding = Encoding.UTF8;
            
            //Change color message
            Console.ForegroundColor = ConsoleColor.Red;
            
            //Time 1 day
            int TimeOneDay = 500;
            
            // Create zooEmulator
            var zoo = new ZooRepo();
            zoo.AddAnimalsForDebug();

            // Create God of death
            var Anubis = new GodOfDeath();
            Anubis.SetWatchPeriod(TimeOneDay);
            Anubis.WatchFor(zoo);
            Anubis.WakeUp();

            // Create menu and app logic
            var engine = new Engine(zoo);
            // Run app logic
            engine.Run();
        }
    }
}