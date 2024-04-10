using Microsoft.AspNetCore.Mvc;
using Web.Contracts.Common;

namespace Web.Contracts.Receipt.Requests
{
    public record GetVariableReceiptsRequest
    {
        public GetVariableReceiptsRequest()
        {
            PageFilter = new PageFilterRequest { Page = 1, PageSize = 60, };
        }

        [FromQuery]
        public PageFilterRequest PageFilter { get; set; }

        [FromQuery]
        public IEnumerable<Guid>? ReceiptIds { get; set; }

        [FromQuery]
        public IEnumerable<Guid>? CategoryIds { get; set; }

        [FromQuery]
        public IEnumerable<string>? EstablishmentNames { get; set; }

        [FromQuery]
        public DateTime ReceiptDate { get; set; }

        [FromQuery]
        public DateTime ReceiptDateFinal { get; set; }

        [FromQuery]
        public IEnumerable<Guid>? ReceiptItemIds { get; set; }

        [FromQuery]
        public IEnumerable<string>? ReceiptItemNames { get; set; }
    }
}
