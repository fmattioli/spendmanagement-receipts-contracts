namespace Contracts.Messaging.V1.Entities
{
    public class VariableReceiptItem(Guid id, string itemName, short quantity, decimal itemPrice, string observation, decimal itemDiscount, decimal totalPrice)
    {
        public Guid Id { get; set; } = id;
        public string ItemName { get; set; } = itemName;
        public short Quantity { get; set; } = quantity;
        public decimal ItemPrice { get; set; } = itemPrice;
        public string Observation { get; set; } = observation;
        public decimal ItemDiscount { get; set; } = itemDiscount;
        public decimal TotalPrice { get; private set; } = totalPrice;
    }
}
