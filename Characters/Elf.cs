namespace CharacterCreator.Characters
{
    // Concrete Product
    public class Elf : Character
    {
        public Elf() : base(health: 80, defense: 40, speed: 70, strength: 40, intellect: 70, agility: 80) { }

        public override void Act() => Console.WriteLine("");
        public override void Speak() => Console.WriteLine("");
    }
}
