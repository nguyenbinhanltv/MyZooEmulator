﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZooEmulator.Animals
{
    class Bear : Animal
    {
        public Bear(string name) : base(name)
        {
            _maxHealth = 6;
            _health = _maxHealth;
        }

        public override AnimalType Type { get { return AnimalType.Bear; } }
    }
}
