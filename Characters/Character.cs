namespace CharacterCreator.Characters
{
    public class Character : ICharacter
    {
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Intellect { get; set; }
        public int Agility { get; set; }

        public Character(int health, int defense, int speed, int strength, int intellect, int agility)
        {
            Health = health;
            Defense = defense;
            Speed = speed;
            Strength = strength;
            Intellect = intellect;
            Agility = agility;
        }

        public void Act()
        {

        }

        public void Speak()
        {

        }

        public void PrintDetails()
        {

        }
    }
}
