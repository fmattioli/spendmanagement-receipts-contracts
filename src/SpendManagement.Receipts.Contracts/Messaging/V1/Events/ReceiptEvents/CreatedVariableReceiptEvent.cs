using Contracts.Messaging.Interfaces;
using Contracts.Messaging.V1.Entities;
using System.Runtime.Serialization;

namespace Contracts.Messaging.V1.Events.ReceiptEvents
{
    public struct CreatedVariableReceiptEvent(VariableReceipt receipt, IEnumerable<VariableReceiptItem> receiptItem) : IEvent
    {
        [IgnoreDataMember]
        public string RoutingKey { get; set; } = receipt.Id.ToString();

        public DateTime EventCreatedDate { get; set; } = DateTime.UtcNow;

        [DataMember(Order = 1)]
        public VariableReceipt Receipt { get; set; } = receipt;

        [DataMember(Order = 2)]
        public IEnumerable<VariableReceiptItem> ReceiptItem { get; set; } = receiptItem;
    }
}
