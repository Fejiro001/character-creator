# Character Creator Simulator

A C# console application that simulates character creation, customization, inventory management, and world progression. The project demonstrates the practical application of four software design patterns: **Singleton, Factory Method, Decorator, Façade and Adpater**.

The application also supports the integration of a legacy character type, Splorg, without modifying its original source code or affecting exisiting game functionality.

## Features

- **Character Creation:** Create Human, Elf, Dwarf or Splorg characters with distinct attributes.
- **Splorg Customization:** Create a Splorg character with a chosen colour (Red, Green, or Blue), each with different starting statistics.
- **Character Customization:** Apply Warrior or Mage specializations to modify character stats and behaviour at runtime.
- **Character Details:** View character attributes, actions, and dialogue.
- **Inventory Management:** Add, remove, search, display, and filter items by category.
- **World Simulation:** View the current world status, advance time, and observe weather changes.
- **Legacy Integration:** Adapt the existing Splorg class to work with the game's character creation, specialization, and inventory systems.
- **Input Validation:** Handle invalid menu choices and prevent duplicate character specializations.

## Design Patterns

This project uses four design patterns to organize its code and separate responsibilities.

| Design Pattern | Category | Purpose | Implementation |
|---|---|---|---|
| Singleton | Creational | Maintains a single shared game world instance. | `GameWorld` |
| Factory Method | Creational | Separates character creation from the game controller. | `CharacterFactory`, `HumanFactory`, `ElfFactory`, `DwarfFactory` |
| Decorator | Structural | Adds character specializations dynamically without modifying the base character class. | `CharacterDecorator`, `WarriorDecorator`, `MageDecorator` |
| Façade | Structural | Provides a simplified interface for inventory operations. | `InventoryFacade`, `Inventory` |
| Adapter | Structural | Integrates an incompatible legacy character into the existing game system without modifying its source code. | `SplorgAdapter`, `Splorg`|

### Singleton -> Game World

The `GameWorld` class manages shared simulation state, including the current region, difficulty, world time, and weather. Its private constructor and shared instance ensure that the application uses a single game world.

### Factory Method -> Character Creation

The abstract `CharacterFactory` defines the character creation contract. Concrete factories create Human, Elf, Dwarf, and Splorg characters, keeping their construction separate from the main game workflow.

The `SplorgFactory` creates a legacy Splorg object using the player's chosen name and colour, then wraps it in a SplorgAdapter before returning it as a standard Character.

### Decorator -> Character Specializations

The `CharacterDecorator` wraps an existing character. `WarriorDecorator` and `MageDecorator` modify character attributes and extend actions and speech at runtime.

Different specializations can be combined without creating a separate subclass for every possible combination. These specializations also work with adapted Splorg characters without modifying the existing decorator classes.

### Façade -> Inventory Management

The `InventoryFacade` provides a straightforward interface for adding, removing, searching, displaying, and filtering inventory items. It hides the details of the underlying inventory collection from the game controller.

The same inventory functionality is available to Splorg characters, and their inventory remains accessible after applying specializations.

### Adapter → Legacy Character Integration

The `SplorgAdapter` allows the existing game engine to interact with the legacy Splorg class through the standard Character base class.

The adapter wraps the legacy Splorg object and translates its properties and methods into the format expected by the game.

#### Statistic Translation

| Legacy Splorg Property | Character Attribute | Translation |
|---|---|---|
| BubbleMatterRemaining | Health | Value × 100 |
| BubbleDurability | Defense | Value × 10 |
| Speed | Speed | Value × 10 |
| Luck | Strength | Value × 10 |
| Smarts | Intellect | Value × 10 |
| Finesse | Agility | Value × 10 |

The multipliers scale the legacy statistics to values comparable with the existing character types. Luck is used to represent Strength based on the Splorg's unpredictable effectiveness in combat.

#### Method Translation
- `Act()` delegates to the legacy `SplorgAction()` method.
- `Speak()` calls the legacy `Communicate()` method and displays the returned sound.
- `PrintDetails()` uses the inherited `Character` implementation to display the translated statistics.

The original `Splorg.cs` remains unchanged. The adapter maintains compatibility with the existing Factory Method, Decorator, and Inventory systems.

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

1. **Create Character** — Choose Human, Elf, Dwarf, or Splorg and enter a name. Splorg characters also require a colour selection.
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
├── Adapters/
│   └── SplorgAdapter.cs
├── Characters/
│   ├── Character.cs
│   ├── Human.cs
│   ├── Elf.cs
│   └── Dwarf.cs
├── Controllers/
│   └── GameController.cs
├── Decorators/
│   ├── CharacterDecorator.cs
│   ├── WarriorDecorator.cs
│   └── MageDecorator.cs
├── Factories/
│   ├── CharacterFactory.cs
│   ├── HumanFactory.cs
│   ├── ElfFactory.cs
│   └── DwarfFactory.cs
│   └── SplorgFactory.cs
├── Inventory/
│   ├── Item.cs
│   ├── ItemCategory.cs
│   ├── Inventory.cs
│   └── InventoryFacade.cs
├── Legacy/
│   └── Splorg.cs
├── GameWorld.cs
└── Program.cs
```

## Learning Objectives

This project demonstrates how design patterns can help build maintainable and extensible applications by:

- Separating object creation from application workflows.
- Managing shared state through a single instance.
- Extending object behaviour dynamically through composition.
- Simplifying access to a subsystem through a unified interface.
- Integrating incompatible legacy code without modifying its original implementation.
- Maintaining compatibility with existing systems when introducing new features.
- Using User Stories and Acceptance Criteria to define requirements and verify functionality.
