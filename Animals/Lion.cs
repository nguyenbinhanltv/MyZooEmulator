using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZooEmulator.Animals
{
    class Lion : Animal
    {
        public Lion(string name) : base(name)
        {
            _maxHealth = 5;
            _health = _maxHealth;
            _weight = 160;
        }       

        public override AnimalType Type { get { return AnimalType.Lion; } }

    }
}
