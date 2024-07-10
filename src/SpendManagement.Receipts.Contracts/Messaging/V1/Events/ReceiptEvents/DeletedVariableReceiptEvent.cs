using Contracts.Messaging.Interfaces;
using System.Runtime.Serialization;

namespace Contracts.Messaging.V1.Events.ReceiptEvents
{
    public struct DeletedVariableReceiptEvent(Guid id) : IEvent
    {
        [IgnoreDataMember]
        public string RoutingKey { get; set; } = id.ToString();

        [IgnoreDataMember]
        public DateTime EventCreatedDate { get; set; } = DateTime.UtcNow;

        [DataMember(Order = 1)]
        public Guid Id { get; set; } = id;
    }
}
