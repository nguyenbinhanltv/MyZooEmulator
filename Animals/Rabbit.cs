namespace MyZooEmulator.Animals
{
    class Rabbit : Animal
    {
        public Rabbit(string name) : base(name)
        {
            _maxHealth = 3;
            _health = _maxHealth;
        }
        
        public override AnimalType Type { get { return AnimalType.Rabbit; } }
    }
}