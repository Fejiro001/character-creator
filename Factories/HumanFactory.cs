using CharacterCreator.Characters;

namespace CharacterCreator.Factories
{
    public class HumanFactory : CharacterFactory
    {
        public override Character CreateCharacter()
        {
            return new Human();
        }
    }
}
