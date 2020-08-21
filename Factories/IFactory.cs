using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyZooEmulator.Animals;

namespace MyZooEmulator.Factories
{
    interface IFactory
    {
        Animal Create(string name);
    }
}
