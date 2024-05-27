namespace Contracts.Web.Receipt.Requests
{
    public class GetDetailedSpentPerCategoryRequest
    {
        public DateTime DateInitial { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
