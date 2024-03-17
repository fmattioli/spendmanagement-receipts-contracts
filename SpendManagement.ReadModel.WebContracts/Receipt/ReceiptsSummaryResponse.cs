namespace SpendManagement.WebContracts.Receipt
{
    public class ReceiptsSummaryResponse
    {
        public IEnumerable<ReceiptResponse> RecurringReceipts { get; set; } = Enumerable.Empty<ReceiptResponse>();
        public IEnumerable<RecurringReceiptResponse> Receipts { get; set; } = Enumerable.Empty<RecurringReceiptResponse>();
    }
}
