namespace Engine.Models
{
    public class ItemQuantity
    {
        public int ItemID { get; }
        public int Quantity { get; }

        public ItemQuantity(int itemId, int quantity)
        {
            ItemID = itemId;
            Quantity = quantity;
        }
    }
}