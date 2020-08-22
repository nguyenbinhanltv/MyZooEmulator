using System;
using MyZooEmulator.Engines;
using MyZooEmulator.Repo;
using MyZooEmulator.Engines;

namespace MyZooEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create zoo repository
            var zoo = new ZooRepo();
            zoo.AddAnimalsForDebug();

            // Create God of death :)
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