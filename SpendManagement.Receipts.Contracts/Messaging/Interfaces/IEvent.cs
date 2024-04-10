namespace Contracts.Messaging.Interfaces
{
    public interface IEvent
    {
        string RoutingKey { get; set; }
        DateTime EventCreatedDate { get; }
    }
}
