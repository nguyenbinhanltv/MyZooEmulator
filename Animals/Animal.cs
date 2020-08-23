using MyZooEmulator.Engines;

namespace MyZooEmulator.Animals
{
    abstract class Animal
    {
        protected string _name;
        protected AnimalStatus _status;
        protected int _health;
        protected int _weight;
        protected int _maxHealth;
               
        public Animal(string name)
        {
            _name = name;
            _status = AnimalStatus.Full;

            // Print message 
            Renderer.PrintMessage($"({Type}) {Name} đã được thêm vào sở thú");
        }

        public string Name { get { return _name; } }
        public AnimalStatus Status { get { return _status; } }
        public int Weight { get { return _weight; } }
        public int Health { get { return _health; } }
        public int MaxHealth { get { return _maxHealth; } }
        public abstract AnimalType Type { get; }

        // Decrease animal status
        public void ChangeStatus()
        {
            if (_status > AnimalStatus.Sick)
            {
                _status--;
                
                Renderer.PrintMessage($"({Type}) {Name} được đổi trạng thái thành {Status}");
            }
            else
            {
                if (_health > 0)
                {
                    _health--;
                    
                    Renderer.PrintMessage($"Sức khỏe sinh vật ({Type}) {Name} giảm thành {Health}");

                    if (_health == 0)
                    {
                        _status = AnimalStatus.Dead;
                        
                        Renderer.PrintMessage($"({Type}) {Name} chết nà");
                    }
                }

            }
        }

        // Feed the animal
        public void Feed()
        {
            if (Status != AnimalStatus.Dead)
            {
                _status = AnimalStatus.Full;
                
                Renderer.PrintMessage($"Sinh vật ({Type}) {Name} ăn, trạng thái: {Status}");
            }
            else
            {
                Renderer.PrintMessage($"({Type}) {Name} đã chết, không cho ăn được âu");

            }

        }

        // Cure the animal
        public void Cure()
        {
            if (Status != AnimalStatus.Dead)
            {
                if (_health < MaxHealth)
                {
                    _health++;
                    
                    Renderer.PrintMessage($"Sinh vật ({Type}) {Name} được chữa bệnh, sức khỏe: {Health}");

                }
                else
                {
                    Renderer.PrintMessage($"Không thể chữa bệnh ({Type}) {Name} vì sức khỏe đang Max");
                }
            }
            else
            {
                Renderer.PrintMessage($"({Type}) {Name} chết òi, không chữa được đâu, thịt thui");

            }

        }

        public override string ToString()
        {
            return $"({Type}) - name: {Name}, status: {Status}, health: {Health}";
        }

    }
}
