namespace CharacterCreator.Inventory
{
    public class Inventory
    {
        private readonly List<Item> _items = new();

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
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
