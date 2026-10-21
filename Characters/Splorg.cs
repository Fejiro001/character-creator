namespace Artifact_Legacy_Code
{
    public class Splorg
    {
        private string[] splorgSounds = new string[]
        {
            "Ploop!",
            "Wee-oo!",
            "Bee-Beep!",
            "Nyoo!",
            "Boink!",
            "Mew!",
            "Bloop!",
            "Pew-Pew!",
            "Waku-Waku!",
            "Boop!"
        };
        Random rng = new Random();
        public string Name { get; set; }
        public string Color { get; set; }
        private string Description { get; set; } = "A species of beings made entirely of soft, squishy bubbles. They can pop and reform at will, and their bodies are highly prone to inflation and deflation. Splorgs communicate through a series of silly, squeaky noises. They have different traits depending on what their color is.";
        public double BubbleMatterRemaining { get; set; } = 1;
        public int BubbleDurability { get; set; } = 5;
        public int Smarts { get; set; } = 5;
        public int Speed { get; set; } = 5;
        public int Finesse { get; set; } = 5;
        public int Luck { get; set; } = 5;
        public Splorg(string name, string color)
        {
            Name = name;
            Color = color;
            InitializeSplorg(color);

        }
        public void InitializeSplorg(string color)
        {
            switch(color)
            {
                case "Red":
                    CreateRedSplorg();
                    break;
                case "Green":
                    CreateBlueSplorg();
                    break;
                case "Blue":
                    CreateGreenSplorg();
                    break;
                default:
                    Console.WriteLine("Invalid color choice. Your Splorg is dead.");
                    BubbleDurability = 0;
                    BubbleMatterRemaining = 0;
                    break;
            }
        }
        public void CreateRedSplorg()
        {
            Smarts += 2;
            BubbleDurability += 2;
            Luck -= 2;
        }
        public void CreateGreenSplorg() 
        { 
            Luck += 2;
            Speed += 2;
            BubbleDurability -= 2;

        }
        public void CreateBlueSplorg()
        {
            Finesse += 2;
            Speed += 2;
            Smarts -= 2;
        }
        public void printDescription()
        {
            Console.WriteLine(Description);
        }
        public string Communicate() 
        {
            int index = rng.Next(splorgSounds.Length);
            return splorgSounds[index];
        }
        public void SplorgAction()
        {
            Console.WriteLine($"{Name} the {Color} Splorg explodes, only to reform in {rng.Next(0, 10)} hours");
        }
    }
}
