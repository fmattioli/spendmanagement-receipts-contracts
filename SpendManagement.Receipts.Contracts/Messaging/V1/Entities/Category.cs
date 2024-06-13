namespace Contracts.Messaging.V1.Entities
{
    public class Category(Guid id, int tenantId, string name, DateTime createdDate)
    {
        public Guid Id { get; set; } = id;
        public int TenantId { get; set; } = tenantId;
        public string? Name { get; set; } = name;
        public DateTime CreatedDate { get; set; } = createdDate;
    }
}
