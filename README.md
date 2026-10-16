# Character Creator Simulator

A C# console application that simulates character creation, customization, inventory management, and world progression. The project demonstrates the practical application of four software design patterns: **Singleton, Factory Method, Decorator, and Façade**.

## Features

- **Character Creation:** Create Human, Elf, or Dwarf characters with distinct attributes.
- **Character Customization:** Apply Warrior or Mage specializations to modify character stats and behaviour at runtime.
- **Character Details:** View character attributes, actions, and dialogue.
- **Inventory Management:** Add, remove, search, display, and filter items by category.
- **World Simulation:** View the current world status, advance time, and observe weather changes.
- **Input Validation:** Handle invalid menu choices and prevent duplicate character specializations.

## Design Patterns

This project uses four design patterns to organize its code and separate responsibilities.

| Design Pattern | Category | Purpose | Implementation |
|---|---|---|---|
| Singleton | Creational | Maintains a single shared game world instance. | `GameWorld` |
| Factory Method | Creational | Separates character creation from the game controller. | `CharacterFactory`, `HumanFactory`, `ElfFactory`, `DwarfFactory` |
| Decorator | Structural | Adds character specializations dynamically without modifying the base character class. | `CharacterDecorator`, `WarriorDecorator`, `MageDecorator` |
| Façade | Structural | Provides a simplified interface for inventory operations. | `InventoryFacade`, `Inventory` |

### Singleton -> Game World

The `GameWorld` class manages shared simulation state, including the current region, difficulty, world time, and weather. Its private constructor and shared instance ensure that the application uses a single game world.

### Factory Method -> Character Creation

The abstract `CharacterFactory` defines the character creation contract. Concrete factories create Human, Elf, and Dwarf characters, keeping their construction separate from the main game workflow.

### Decorator -> Character Specializations

The `CharacterDecorator` wraps an existing character. `WarriorDecorator` and `MageDecorator` modify character attributes and extend actions and speech at runtime. Different specializations can be combined without creating a separate subclass for every possible combination.

### Façade -> Inventory Management

The `InventoryFacade` provides a straightforward interface for adding, removing, searching, displaying, and filtering inventory items. It hides the details of the underlying inventory collection from the game controller.

## Technologies

- **Language:** C#
- **Platform:** .NET
- **Application Type:** Console application
- **Concepts:** Object-oriented programming, design patterns, encapsulation, inheritance, and composition

## Getting Started

### Prerequisites

- The .NET SDK compatible with the project's target framework.
- A code editor or IDE, such as Visual Studio or Visual Studio Code.

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/Fejiro001/character-creator.git
   ```

2. Navigate to the project directory:

   ```bash
   cd CharacterCreator
   ```

3. Restore dependencies:

   ```bash
   dotnet restore
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

If the repository contains a solution with multiple projects, navigate to the directory containing the console application's `.csproj` file or specify the project path when running the commands.

## How to Use

When the application starts, use the main menu to select an operation:

1. **Create Character** — Choose a character type and enter a name.
2. **Customize Character** — Apply a Warrior or Mage specialization.
3. **View Character** — Display character attributes, actions, and speech.
4. **Manage Inventory** — Collect items, use items, search, filter, or display inventory contents.
5. **World Simulation** — View world status, perform character actions, or advance world time.
0. **Exit** — Close the application.

Follow the on-screen prompts to navigate each menu. Create a character before accessing character-specific features.

## Project Structure

The project is organized by responsibility.

```text
CharacterCreator/
├── Controllers/
│   └── GameController.cs
├── Characters/
│   ├── Character.cs
│   ├── Human.cs
│   ├── Elf.cs
│   └── Dwarf.cs
├── Decorators/
│   ├── CharacterDecorator.cs
│   ├── WarriorDecorator.cs
│   └── MageDecorator.cs
├── Factories/
│   ├── CharacterFactory.cs
│   ├── HumanFactory.cs
│   ├── ElfFactory.cs
│   └── DwarfFactory.cs
├── Inventory/
│   ├── Item.cs
│   ├── ItemCategory.cs
│   ├── Inventory.cs
│   └── InventoryFacade.cs
├── GameWorld.cs
└── Program.cs
```

## Learning Objectives

This project demonstrates how design patterns can help build maintainable and extensible applications by:

- Separating object creation from application workflows.
- Managing shared state through a single instance.
- Extending object behaviour dynamically through composition.
- Simplifying access to a subsystem through a unified interface.
- Organizing application logic into focused classes and responsibilities.
