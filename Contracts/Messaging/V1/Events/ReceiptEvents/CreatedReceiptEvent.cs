using Contracts.Messaging.Interfaces;
using Contracts.Messaging.V1.Entities;
using System.Runtime.Serialization;

namespace Contracts.Messaging.V1.Events.ReceiptEvents
{
    public struct CreatedReceiptEvent(Receipt receipt, IEnumerable<ReceiptItem> receiptItem) : IEvent
    {
        [IgnoreDataMember]
        public string RoutingKey { get; set; } = receipt.Id.ToString();

        public DateTime EventCreatedDate { get; set; } = DateTime.UtcNow;

        [DataMember(Order = 1)]
        public Receipt Receipt { get; set; } = receipt;

        [DataMember(Order = 2)]
        public IEnumerable<ReceiptItem> ReceiptItem { get; set; } = receiptItem;
    }
}
