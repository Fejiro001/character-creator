namespace CharacterCreator.Inventory
{
    public class Item
    {
        public string Name { get; set; }
        public ItemCategory Category { get; set; }
        public string Description { get; set; }

        public Item(string name, ItemCategory category, string description)
        {
            Name = name;
            Category = category;
            Description = description;
        }
    }
}
