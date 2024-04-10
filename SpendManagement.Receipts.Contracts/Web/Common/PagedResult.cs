using System.Text.Json.Serialization;

namespace Contracts.Web.Common
{
    public class PagedResult<T>
    {
        public PagedResult() => Results = [];

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public decimal TotalAmount { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}
