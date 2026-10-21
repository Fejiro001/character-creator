using CharacterCreator.Characters;
using CharacterCreator.Decorators;
using CharacterCreator.Factories;
using CharacterCreator.Inventory;

namespace CharacterCreator.Controllers
{
    public class GameController
    {
        private const int ExitOption = 0;
        private const int CreateCharacterOption = 1;
        private const int CustomizeCharacterOption = 2;
        private const int ViewCharacterOption = 3;
        private const int ManageInventoryOption = 4;
        private const int WorldSimulationOption = 5;

        public void RunGame()
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
                        Character? newCharacter = CreateCharacter();
                        if (newCharacter != null)
                        {
                            character = newCharacter;
                        }
                        break;
                    case CustomizeCharacterOption:
                        character = CustomizeCharacter(character);
                        break;
                    case ViewCharacterOption:
                        ViewCharacter(character);
                        break;
                    case ManageInventoryOption:
                        ManageInventory(character);
                        break;
                    case WorldSimulationOption:
                        RunSimulation(character, gameWorld);
                        break;
                    case ExitOption:
                        gameRunning = false;
                        Console.WriteLine("Exiting Character Creator Simulator...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid menu option.");
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\n========= CHARACTER CREATOR SIMULATOR =========");
            Console.WriteLine("Main Menu");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Select an option: ");
            Console.WriteLine("1. Create Character");
            Console.WriteLine("2. Customize Character");
            Console.WriteLine("3. View Character");
            Console.WriteLine("4. Manage Inventory");
            Console.WriteLine("5. World Simulation");
            Console.WriteLine("0. Exit");
            Console.WriteLine("================================================\n");
        }

        private int ReadMenuChoice()
        {
            Console.WriteLine("Select an option: ");
            string? input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, out int choice))
            {
                return choice;
            }

            return -1;
        }

        private Character? CreateCharacter()
        {
            string color = string.Empty;

            Console.WriteLine("\n=== CREATE CHARACTER ===");
            Console.WriteLine("Choose a character type:");
            Console.WriteLine("1. Human");
            Console.WriteLine("2. Elf");
            Console.WriteLine("3. Dwarf");
            Console.WriteLine("4. Splorg");

            if (!int.TryParse(Console.ReadLine()?.Trim(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return null;
            }

            if (choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid character type.");
                return null;
            }

            Console.WriteLine("Enter your character's name:");
            string? name = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty. Character creation cancelled.");
                return null;
            }

            if (choice == 4)
            {
                Console.WriteLine("Enter your Splorg's color (Red, Green, Blue):");
                string? enteredColor = Console.ReadLine()?.Trim();

                color = enteredColor?.ToLowerInvariant() switch
                {
                    "red" => "Red",
                    "green" => "Green",
                    "blue" => "Blue",
                    _ => string.Empty
                };

                if (string.IsNullOrWhiteSpace(color))
                {
                    Console.WriteLine("Invalid color. Character creation cancelled.");
                    return null;
                }
            }

            // Used a switch expression
            CharacterFactory? factory = choice switch
            {
                1 => new HumanFactory(),
                2 => new ElfFactory(),
                3 => new DwarfFactory(),
                4 => new SplorgFactory(name, color),
                _ => throw new InvalidOperationException("Invalid character type.")
            };

            // Using the character factory
            Character character = factory.CreateCharacter();

            character.Name = name;

            string characterType = choice == 4
                ? "Splorg"
                : character.GetType().Name;

            Console.WriteLine($"{character.Name} the {characterType} has been created.");
            return character;
        }

        private Character? CustomizeCharacter(Character? character)
        {
            if (character == null)
            {
                Console.WriteLine("Create a character first.");
                return null;
            }

            Console.WriteLine("\n=== CUSTOMIZE CHARACTER ===");
            Console.WriteLine("Choose a specialization:");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("0. Return");

            if (!int.TryParse(Console.ReadLine()?.Trim(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return character;
            }

            switch (choice)
            {
                case 1:
                    if (HasSpecialization(character, typeof(WarriorDecorator)))
                    {
                        Console.WriteLine("This character already has the Warrior specialization.");
                        return character;
                    }

                    character = new WarriorDecorator(character);
                    Console.WriteLine($"{character.Name} has received a Warrior specialization.");
                    break;
                case 2:
                    if (HasSpecialization(character, typeof(MageDecorator)))
                    {
                        Console.WriteLine("This character already has the Mage specialization.");
                        return character;
                    }

                    character = new MageDecorator(character);
                    Console.WriteLine($"{character.Name} has received a Mage specialization.");
                    break;
                case 0:
                    return character;
                default:
                    Console.WriteLine("Invalid specialization.");
                    return character;
            }

            return character;
        }

        private void ViewCharacter(Character? character)
        {
            if (character == null)
            {
                Console.WriteLine("Create a character first.");
                return;
            }

            Console.WriteLine("\n=== CHARACTER DETAILS ===");
            character.PrintDetails();

            Console.WriteLine("\n=== CHARACTER ACTION ===");
            character.Act();

            Console.WriteLine("\n=== CHARACTER SPEECH ===");
            character.Speak();
        }

        private void ManageInventory(Character? character)
        {
            if (character == null)
            {
                Console.WriteLine("Create a character first.");
                return;
            }

            bool inventoryMenuRunning = true;

            while (inventoryMenuRunning)
            {
                Console.WriteLine("\n=== INVENTORY MENU ===");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Collect an Item");
                Console.WriteLine("2. Use an Item");
                Console.WriteLine("3. Search for Item");
                Console.WriteLine("4. Filter Items by Category");
                Console.WriteLine("5. Display Inventory");
                Console.WriteLine("0. Return");

                if (!int.TryParse(Console.ReadLine()?.Trim(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddInventoryItem(character);
                        break;
                    case 2:
                        Console.WriteLine("Enter the item you want to use:");
                        character.Inventory.TakeItem(Console.ReadLine()?.Trim() ?? "");
                        break;
                    case 3:
                        Console.WriteLine("Enter the item to search for:");
                        character.Inventory.SearchItem(Console.ReadLine()?.Trim() ?? "");
                        break;
                    case 4:
                        FilterInventory(character);
                        break;
                    case 5:
                        character.Inventory.DisplayInventory();
                        break;
                    case 0:
                        inventoryMenuRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void AddInventoryItem(Character character)
        {
            Console.WriteLine("Enter item name:");
            string? name = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Item name cannot be empty.");
                return;
            }

            Console.WriteLine("\nChoose a category:");
            Console.WriteLine("1. Weapon\n2. Potion\n3. Spellbook\n4. HouseItem\n");

            if (!int.TryParse(Console.ReadLine()?.Trim(), out int categoryChoice))
            {
                Console.WriteLine("Invalid category.");
                return;
            }

            ItemCategory? category = categoryChoice switch
            {
                1 => ItemCategory.Weapon,
                2 => ItemCategory.Potion,
                3 => ItemCategory.Spellbook,
                4 => ItemCategory.HouseItem,
                _ => null
            };

            if (category == null)
            {
                Console.WriteLine("Invalid category.");
                return;
            }

            Console.WriteLine("Enter item description:");
            string? description = Console.ReadLine()?.Trim();

            string itemDescription = string.IsNullOrWhiteSpace(description)
                ? "No description provided."
                : description;

            Item item = new Item(
                name,
                category.Value,
                itemDescription
            );

            character.Inventory.GiveItem(item);
        }

        private void FilterInventory(Character character)
        {
            Console.WriteLine("\nChoose a category:");
            Console.WriteLine("1. Weapon\n2. Potion\n3. Spellbook\n4. HouseItem\n");

            if (!int.TryParse(Console.ReadLine()?.Trim(), out int choice))
            {
                Console.WriteLine("Invalid category.");
                return;
            }

            ItemCategory? category = choice switch
            {
                1 => ItemCategory.Weapon,
                2 => ItemCategory.Potion,
                3 => ItemCategory.Spellbook,
                4 => ItemCategory.HouseItem,
                _ => null
            };

            if (category == null)
            {
                Console.WriteLine("Invalid category.");
                return;
            }

            character.Inventory.GetItemsByCategory(category.Value);
        }

        private void RunSimulation(Character? character, GameWorld gameWorld)
        {
            bool simulationRunning = true;

            while (simulationRunning)
            {
                Console.WriteLine("\n=== WORLD SIMULATION ===");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Perform Character Action");
                Console.WriteLine("2. View World Status");
                Console.WriteLine("3. Advance Time Manually");
                Console.WriteLine("0. Return to Main Menu");

                if (!int.TryParse(Console.ReadLine()?.Trim(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        if (character == null)
                        {
                            Console.WriteLine("Create a character before performing an action.");
                            break;
                        }

                        character.Act();
                        gameWorld.AdvanceTime();
                        break;
                    case 2:
                        gameWorld.DisplayWorldStatus();
                        break;
                    case 3:
                        gameWorld.AdvanceTime();
                        break;
                    case 0:
                        simulationRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private bool HasSpecialization(Character character, Type specializationType)
        {
            return character is CharacterDecorator decorator && decorator.HasSpecialization(specializationType);
        }
    }
}
