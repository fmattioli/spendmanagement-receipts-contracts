using Contracts.Messaging.Interfaces;
using Contracts.Messaging.V1.Entities;
using System.Runtime.Serialization;

namespace Contracts.Messaging.V1.Events.RecurringReceiptEvents
{
    public struct UpdatedRecurringReceiptEvent(RecurringReceipt recurringReceipt) : IEvent
    {
        [IgnoreDataMember]
        public string RoutingKey { get; set; } = recurringReceipt.Id.ToString();

        [IgnoreDataMember]
        public DateTime EventCreatedDate { get; set; } = DateTime.UtcNow;

        [DataMember(Order = 1)]
        public RecurringReceipt RecurringReceipt { get; set; } = recurringReceipt;
    }
}
