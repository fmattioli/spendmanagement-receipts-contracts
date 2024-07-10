using Contracts.Web.Attributes;

namespace Contracts.Web.Http.Category.Responses
{
    public class CategoryResponse
    {
        [NonEditable]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [NonEditable]
        public DateTime CreatedDate { get; set; }
    }
}
