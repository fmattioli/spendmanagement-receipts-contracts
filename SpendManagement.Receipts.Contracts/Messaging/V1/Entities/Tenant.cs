namespace Contracts.Messaging.V1.Entities
{
    public class Tenant(int number)
    {
        public int Number { get; set; } = number;
    }
}
