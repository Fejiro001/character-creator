using CharacterCreator.Characters;

namespace CharacterCreator.Factories
{
    public class DwarfFactory : CharacterFactory
    {
        public override Character CreateCharacter()
        {
            return new Dwarf();
        }
    }
}
