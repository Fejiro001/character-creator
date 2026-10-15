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
    }
}
