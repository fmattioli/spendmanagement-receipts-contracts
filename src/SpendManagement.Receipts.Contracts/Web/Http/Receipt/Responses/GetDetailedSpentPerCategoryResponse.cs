namespace Contracts.Web.Http.Receipt.Responses
{
    public class GetDetailedSpentPerCategoryResponse
    {
        public short Year { get; set; }
        public short Month { get; set; }
        public decimal TotalSpentMonthly { get; set; }
        public List<DetailedSpendsResponse>? DetailedSpends { get; set; }
    }

    public class DetailedSpendsResponse
    {
        public string? CategoryName { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
