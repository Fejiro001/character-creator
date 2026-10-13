namespace CharacterCreator.Characters
{
    // Concrete Product
    public class Human : Character
    {
        public Human() : base(health: 100, defense: 50, speed: 60, strength: 50, intellect: 50, agility: 50) { }

        public override void Act() => Console.WriteLine("Human assesses the battlefield, ready to adapt to any challenge.");
        public override void Speak() => Console.WriteLine("We stand together, whatever comes our way!");
    }
}
