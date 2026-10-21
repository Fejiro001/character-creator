using Artifact_Legacy_Code;
using CharacterCreator.Adapters;
using CharacterCreator.Characters;

namespace CharacterCreator.Factories
{
    public class SplorgFactory : CharacterFactory
    {
        private readonly string _name;
        private readonly string _color;
        public SplorgFactory(string name, string color)
        {
            _name = name;
            _color = color;
        }
        public override Character CreateCharacter()
        {
            return new SplorgAdapter(new Splorg(_name, _color));
        }
    }
}
