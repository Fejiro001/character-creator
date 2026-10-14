using CharacterCreator.Characters;

namespace CharacterCreator.Decorators
{
    public class WarriorDecorator : CharacterDecorator
    {
        public WarriorDecorator(Character character) : base(character)
        {
            Strength += 20;
            Defense += 15;
        }

        public override void Act()
        {
            base.Act();
            Console.WriteLine(" [Warrior Specialization]: Takes a defensive stance and brandishes a heavy weapon!");
        }

        public override void Speak()
        {
            base.Speak();
            Console.WriteLine(" [Warrior Specialization]: 'Victory favors the strong!'");
        }
    }
}
