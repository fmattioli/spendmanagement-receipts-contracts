namespace Contracts.Messaging.V1.Entities
{
    public class VariableReceipt(Guid id, Guid userId, Tenant tenant, Category category, string establishmentName, DateTime receiptDate, decimal discount, decimal total)
    {
        public Guid Id { get; set; } = id;
        public Guid UserId { get; set; } = userId;
        public Tenant Tenant { get; set; } = tenant;
        public Category Category { get; set; } = category;
        public DateTime ReceiptDate { get; set; } = receiptDate;
        public string EstablishmentName { get; set; } = establishmentName;
        public decimal Total { get; set; } = total;
        public decimal Discount { get; set; } = discount;
    }
}
