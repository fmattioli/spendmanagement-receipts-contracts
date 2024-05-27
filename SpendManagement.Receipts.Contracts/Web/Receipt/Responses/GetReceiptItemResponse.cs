namespace Contracts.Web.Receipt.Responses
{
    public class GetReceiptItemResponse
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; } = null!;
        public short Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Observation { get; set; } = null!;
        public decimal ItemDiscount { get; set; }
    }
}
