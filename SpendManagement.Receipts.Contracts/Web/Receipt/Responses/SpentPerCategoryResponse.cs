namespace Contracts.Web.Receipt.Responses
{
    public class SpentPerCategoryResponse
    {
        public short Year { get; set; }
        public short Month { get; set; }
        public decimal TotalSpentMonthly { get; set; }
        public List<SpentDetailResponse>? SpentDetails { get; set; }
    }
}
