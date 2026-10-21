using Artifact_Legacy_Code;
using CharacterCreator.Characters;

namespace CharacterCreator.Adapters
{
    public class SplorgAdapter : Character
    {
        private readonly Splorg _splorg;
        // Translate legacy Splorg statistics into standard Character attributes.
        // BubbleMatterRemaining -> Health. Determines how much bubble matter remains.
        // BubbleDurability -> Defense. Represents resistance to damage.
        // Speed -> Speed
        // Smarts -> Intellect
        // Finesse -> Agility because it represents coordination and precision.
        // Luck -> Strength. It represents the Splorg's unpredictable effectiveness in combat.
        // Multipliers scale the legacy values to match the game's stat range.
        public SplorgAdapter(Splorg splorg)
            : base(
                (int)(splorg.BubbleMatterRemaining * 100),
                splorg.BubbleDurability * 10,
                splorg.Speed * 10,
                splorg.Luck * 10,
                splorg.Smarts * 10,
                splorg.Finesse * 10
            )
        {
            _splorg = splorg;
            Name = splorg.Name;
        }
        public override void Act()
        {
            _splorg.SplorgAction();
        }

        public override void Speak()
        {
            Console.WriteLine(_splorg.Communicate());
        }
    }
}
