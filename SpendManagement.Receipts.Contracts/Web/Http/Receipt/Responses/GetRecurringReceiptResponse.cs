using Contracts.Web.Attributes;
using Contracts.Web.Http.Category.Responses;

namespace Contracts.Web.Http.Receipt.Responses
{
    public class GetRecurringReceiptResponse
    {
        [NonEditable]
        public Guid Id { get; set; }
        public CategoryResponse? Category { get; set; }
        public string? EstablishmentName { get; set; }
        public DateTime DateInitialRecurrence { get; set; }
        public DateTime DateEndRecurrence { get; set; }
        public decimal RecurrenceTotalPrice { get; set; }
        public string? Observation { get; set; }
    }
}
