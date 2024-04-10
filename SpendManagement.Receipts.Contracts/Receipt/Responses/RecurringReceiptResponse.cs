using Web.Contracts.Category.Responses;

namespace Web.Contracts.Receipt.Responses
{
    public class RecurringReceiptResponse
    {
        public Guid Id { get; set; }
        public CategoryResponse? Category { get; set; }
        public string? EstablishmentName { get; set; }
        public DateTime DateInitialRecurrence { get; set; }
        public DateTime DateEndRecurrence { get; set; }
        public decimal RecurrenceTotalPrice { get; set; }
        public string? Observation { get; set; }
    }
}
