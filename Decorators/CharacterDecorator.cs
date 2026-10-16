using CharacterCreator.Characters;
using CharacterCreator.Inventory;

namespace CharacterCreator.Decorators
{
    public abstract class CharacterDecorator : Character
    {
        protected readonly Character _character;

        protected CharacterDecorator(Character character)
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
            Name = character.Name;
        }

        // Delegates inventory access to the original character
        public override InventoryFacade Inventory => _character.Inventory;

        public override void Act() => _character.Act();

        public override void Speak() => _character.Speak();

        public bool HasSpecialization(Type specializationType)
        {
            if (specializationType.IsInstanceOfType(this))
            {
                return true;
            }

            if (_character is CharacterDecorator decorator)
            {
                return decorator.HasSpecialization(specializationType);
            }

            return false;
        }
    }
}
