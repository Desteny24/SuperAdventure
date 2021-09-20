using Engine.Actions;

namespace Engine.Models
{
    public class GameItem
    {
        public ItemCategory Category { get; }
        public IAction Action { get; set; }
        public int ItemTypeID { get; }
        public string Name { get; }
        public int Price { get; }
        public bool IsUnique { get; }

        public GameItem(ItemCategory category, int itemTypeId, string name, int price, bool isUnique = false, IAction action = null)
        {
            Category = category;
            ItemTypeID = itemTypeId;
            Name = name;
            Price = price;
            IsUnique = isUnique;
            Action = action;
        }

        public GameItem Clone()
        {
            return new GameItem(Category, ItemTypeID, Name, Price, IsUnique, Action);
        }

        public void PerformAction(LivingEntity actor, LivingEntity target)
        {
            Action?.Execute(actor, target);
        }

        public enum ItemCategory
        {
            Miscellaneous,
            Weapon,
            Consumable
        }
    }
}