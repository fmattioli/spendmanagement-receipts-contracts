using Web.Contracts.Receipt;

namespace SpendManagement.WebContracts.Receipt
{
    public class ReceiptResponse
    {
        public Guid Id { get; set; }
        public string EstablishmentName { get; set; } = null!;
        public DateTime ReceiptDate { get; set; }
        public IEnumerable<ReceiptItemResponse> ReceiptItems { get; set; } = null!;
    }
}
