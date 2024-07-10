using Contracts.Web.Http.Common;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Web.Http.Receipt.Requests
{
    public class GetRecurringReceiptsRequest
    {
        public GetRecurringReceiptsRequest()
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
    }
}
