using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZooEmulator.Animals
{
    class Tiger : Animal
    {
        public Tiger(string name) : base(name)
        {
            _maxHealth = 4;
            _health = _maxHealth;
            _weight = 150;
        }

        public override AnimalType Type { get { return AnimalType.Tiger; } }
    }
}
