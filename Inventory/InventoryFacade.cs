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
    }
}
