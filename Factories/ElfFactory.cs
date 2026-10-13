using CharacterCreator.Characters;

namespace CharacterCreator.Factories
{
    public class ElfFactory : CharacterFactory
    {
        public override Character CreateCharacter()
        {
            return new Elf();
        }
    }
}
