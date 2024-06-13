namespace Contracts.Messaging.V1.Entities
{
    public class VariableReceipt(Guid id, int tenantId, Category category, string establishmentName, DateTime receiptDate, decimal discount, decimal total)
    {
        public Guid Id { get; set; } = id;
        public int TenantId { get; set; } = tenantId;
        public Category Category { get; set; } = category;
        public string EstablishmentName { get; set; } = establishmentName;
        public DateTime ReceiptDate { get; set; } = receiptDate;
        public decimal Total { get; set; } = total;
        public decimal Discount { get; set; } = discount;

        public bool Validate()
        {
            if (!string.IsNullOrEmpty(EstablishmentName)
                && ReceiptDate.Date != DateTime.MinValue
                && Id != Guid.Empty)
            {
                return true;
            }

            return false;
        }
    }
}
