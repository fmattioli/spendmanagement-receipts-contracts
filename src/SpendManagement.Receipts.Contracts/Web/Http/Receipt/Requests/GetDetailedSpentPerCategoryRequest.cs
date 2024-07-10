namespace Contracts.Web.Http.Receipt.Requests
{
    public class GetDetailedSpentPerCategoryRequest
    {
        public DateTime DateInitial { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
