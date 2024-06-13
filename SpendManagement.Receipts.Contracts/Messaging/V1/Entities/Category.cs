namespace Contracts.Messaging.V1.Entities
{
    public class Category(Guid id, Tenant tenant, string name, DateTime createdDate)
    {
        public Guid Id { get; set; } = id;
        public Tenant Tenant { get; set; } = tenant;
        public string? Name { get; set; } = name;
        public DateTime CreatedDate { get; set; } = createdDate;
    }
}
