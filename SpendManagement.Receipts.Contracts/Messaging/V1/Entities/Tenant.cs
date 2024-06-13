namespace Contracts.Messaging.V1.Entities
{
    public class Tenant(int id, Guid userId)
    {
        public int Id { get; set; } = id;
        public Guid UserId { get; set; } = userId;
    }
}
