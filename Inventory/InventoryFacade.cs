namespace CharacterCreator.Inventory
{
    public class InventoryFacade
    {
        private readonly Inventory _inventory;

        public InventoryFacade()
        {
            _inventory = new Inventory();
        }

        public void GiveItem(Item item)
        {
            _inventory.AddItem(item);
            Console.WriteLine($"[Inventory]: {item.Name} was added to the inventory.");
        }

        public void TakeItem(string itemName)
        {
            Item? itemFound = _inventory.FindItem(itemName);

            if (itemFound != null)
            {
                _inventory.RemoveItem(itemFound);
                Console.WriteLine($"\n[Inventory]: {itemFound.Name} was removed from the inventory.");
            }
            else
            {
                Console.WriteLine($"\nCould not find '{itemName}' in the inventory.");
            }
        }


        public void SearchItem(string itemName)
        {
            Item? itemFound = _inventory.FindItem(itemName);

            if (itemFound != null)
            {
                Console.WriteLine("\n=== Item Found ===");
                Console.WriteLine($"Name: {itemFound.Name}");
                Console.WriteLine($"Category: {itemFound.Category}");
                Console.WriteLine($"Description: {itemFound.Description}");
            }
            else
            {
                Console.WriteLine($"\n'{itemName}' was not found in the inventory.");
            }
        }

        public void GetItemsByCategory(ItemCategory category)
        {
            List<Item> items = _inventory.FilterItemsByCategory(category);

            Console.WriteLine($"\n=== {category} Items ===");

            if (items.Count == 0)
            {
                Console.WriteLine($"No items found in the {category} category.");
                return;
            }

            foreach (Item item in items)
            {
                Console.WriteLine($"- {item.Name}: {item.Description}");
            }
        }

        public void DisplayInventory()
        {
            List<Item> items = _inventory.GetAllItems();
            Console.WriteLine("\n=== Character Inventory ===");

            if (items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
                return;
            }

            foreach (Item item in items)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Category: {item.Category}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine("---------------------------------------------------");
            }

            Console.WriteLine($"Total items: {items.Count}\n");
        }
    }
}
