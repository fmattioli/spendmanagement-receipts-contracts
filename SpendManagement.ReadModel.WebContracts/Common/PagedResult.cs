using System.Text.Json.Serialization;

namespace SpendManagement.WebContracts.Common
{
    public class PagedResult<T>
    {
        public PagedResult()
        {
            Results = new List<T>();
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageSizeLimit { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double TotalAmount { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}
