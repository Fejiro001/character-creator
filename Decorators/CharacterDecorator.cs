using CharacterCreator.Characters;

namespace CharacterCreator.Decorators
{
    public abstract class CharacterDecorator : Character
    {
        protected readonly Character _character;

        public CharacterDecorator(Character character)
            : base(
                  health: character.Health,
                  defense: character.Defense,
                  speed: character.Speed,
                  strength: character.Strength,
                  intellect: character.Intellect,
                  agility: character.Agility
            )
        {
            _character = character;
        }

        public override void Act() => _character.Act();

        public override void Speak() => _character.Speak();

        public override void PrintDetails() => _character.PrintDetails();
    }
}
