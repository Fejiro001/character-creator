namespace CharacterCreator.Characters
{
    // Product Class
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Intellect { get; set; }
        public int Agility { get; set; }

        protected Character(int health, int defense, int speed, int strength, int intellect, int agility)
        {
            Health = health;
            Defense = defense;
            Speed = speed;
            Strength = strength;
            Intellect = intellect;
            Agility = agility;
        }

        public abstract void Act();
        public abstract void Speak();

        public virtual void PrintDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Intellect: {Intellect}");
            Console.WriteLine($"Agility: {Agility}");
        }
    }
}
