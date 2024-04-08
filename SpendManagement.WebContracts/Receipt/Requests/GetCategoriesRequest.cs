using Microsoft.AspNetCore.Mvc;

namespace Web.Contracts.Receipt.Requests
{
    public record GetCategoriesRequest
    {
        public GetCategoriesRequest()
        {
            PageFilter = new PageFilterRequest { Page = 1, PageSize = 60, };
        }

        [FromQuery]
        public PageFilterRequest PageFilter { get; set; }

        [FromQuery(Name = "categoryIds")]
        public IEnumerable<Guid> CategoryIds { get; set; } = [];

        [FromQuery(Name = "categoryNames")]
        public IEnumerable<string> CategoryNames { get; set; } = [];
    }
}
