using CharacterCreator.Characters;

namespace CharacterCreator.Decorators
{
    public class MageDecorator : CharacterDecorator
    {
        public MageDecorator(Character character) : base(character)
        {
            Intellect += 25;
            Speed += 5;
        }

        public override void Act()
        {
            base.Act();
            Console.WriteLine(" [Mage Specialization]: Waves hands and chants an ancient spell formula!");
        }

        public override void Speak()
        {
            base.Speak();
            Console.WriteLine(" [Mage Specialization]: 'The fabric of reality bends to my will.'");
        }
    }
}
