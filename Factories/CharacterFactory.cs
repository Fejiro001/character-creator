using CharacterCreator.Characters;

namespace CharacterCreator.Factories
{
    // Creator Class
    public abstract class CharacterFactory
    {
        // The Factory method
        public abstract Character CreateCharacter();
    }
}
