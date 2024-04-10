namespace Contracts.Messaging.Interfaces
{
    public interface ICommand
    {
        string RoutingKey { get; }
        DateTime CommandCreatedDate { get; }
    }
}
