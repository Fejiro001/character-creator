namespace CharacterCreator.Inventory
{
    public class Inventory
    {
        private readonly List<Item> _items = new();

        public void AddItem(Item item)
        {
            _items.Add(item);
            Console.WriteLine($"[Inventory] Added: {item.Name}");
        }

        public void RemoveItem(Item item)
        {
            bool itemRemoved = _items.Remove(item);
            if (itemRemoved)
            {
                Console.WriteLine($"[Inventory] Removed: {item.Name}");
            }
            else
            {
                Console.WriteLine($"[Inventory] Item not found: {item.Name}");
            }
        }

        public Item? FindItem(string itemName)
        {
            return _items.FirstOrDefault(
                item => item.Name.Equals(
                    itemName,
                    StringComparison.OrdinalIgnoreCase));
        }

        public List<Item> FilterItemsByCategory(ItemCategory category)
        {
            return _items.FindAll(item => item.Category == category);
        }

        public List<Item> GetAllItems()
        {
            return new List<Item>(_items);
        }
    }
}
