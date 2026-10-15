using CharacterCreator.Characters;
using CharacterCreator.Factories;

namespace CharacterCreator
{
    internal class Program
    {
        private const int ExitOption = 0;
        private const int CreateCharacterOption = 1;
        private const int CustomizeCharacterOption = 2;
        private const int ViewCharacterOption = 3;
        private const int ManageInventoryOption = 4;
        private const int WorldSimulationOption = 5;

        static void Main(string[] args)
        {
            RunGame();
        }

        static void RunGame()
        {
            bool gameRunning = true;
            Character? character = null;

            // Singleton instance
            GameWorld gameWorld = GameWorld.GetInstance();

            while (gameRunning)
            {
                DisplayMenu();

                int choice = ReadMenuChoice();

                switch (choice)
                {
                    case CreateCharacterOption:
                        character = CreateCharacter();
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\n========= CHARACTER CREATOR SIMULATOR =========");
            Console.WriteLine("Main Menu");
            Console.WriteLine("Select an option: ");
            Console.WriteLine("1. Create Character");
            Console.WriteLine("2. Customize Character");
            Console.WriteLine("3. View Character");
            Console.WriteLine("4. Manage Inventory");
            Console.WriteLine("5. World Simulation");
            Console.WriteLine("0. Exit");
            Console.WriteLine("================================================");
        }

        static int ReadMenuChoice()
        {
            Console.WriteLine("Select an option: ");
            string? input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, out int choice))
            {
                return choice;
            }

            return -1;
        }

        static Character? CreateCharacter()
        {
            Console.WriteLine("\n=== Create Character ===");
            Console.WriteLine("Choose a character type:");
            Console.WriteLine("1. Human");
            Console.WriteLine("2. Elf");
            Console.WriteLine("3. Dwarf");

            if (!int.TryParse(Console.ReadLine()?.Trim(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return null;
            }

            // Used a switch expression
            CharacterFactory? factory = choice switch
            {
                1 => new HumanFactory(),
                2 => new ElfFactory(),
                3 => new DwarfFactory(),
                _ => null
            };

            if (factory == null)
            {
                Console.WriteLine("Invalid character type.");
                return null;
            }

            // Using the character factory
            Character character = factory.CreateCharacter();

            Console.WriteLine("Enter your character's name:");
            string? name = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty. Character creation cancelled.");
                return null;
            }

            Console.WriteLine($"{character.Name} the {character.GetType().Name} has been created.");
            return character;
        }
    }
}
