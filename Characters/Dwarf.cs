namespace CharacterCreator.Characters
{
    // Concrete Product
    public class Dwarf : Character
    {
        public Dwarf() : base(health: 120, defense: 80, speed: 40, strength: 80, intellect: 40, agility: 30) { }

        public override void Act() => Console.WriteLine($"{Name} the Dwarf firmly plants their boots and raises a sturdy battle-axe.");
        public override void Speak() => Console.WriteLine("By my beard, this rock holds firm!");
    }
}
