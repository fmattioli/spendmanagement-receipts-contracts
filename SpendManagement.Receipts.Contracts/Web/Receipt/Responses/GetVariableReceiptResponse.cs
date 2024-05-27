using Contracts.Web.Attributes;
using Contracts.Web.Category.Responses;

namespace Contracts.Web.Receipt.Responses
{
    public class GetVariableReceiptResponse
    {
        [NonEditable]
        public Guid Id { get; set; }
        public CategoryResponse Category { get; set; } = null!;
        public string EstablishmentName { get; set; } = null!;
        public DateTime ReceiptDate { get; set; }
        public IEnumerable<GetReceiptItemResponse> ReceiptItems { get; set; } = null!;
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
    }
}
