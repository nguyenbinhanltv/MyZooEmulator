﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZooEmulator.Animals
{
    class Fox : Animal
    {
        public Fox(string name) : base(name)
        {
            _maxHealth = 3;
            _health = _maxHealth;
        }

        public override AnimalType Type { get { return AnimalType.Fox; } }
    }
}
