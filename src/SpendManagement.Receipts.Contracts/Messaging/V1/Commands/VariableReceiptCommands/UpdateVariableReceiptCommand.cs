using Contracts.Messaging.Interfaces;
using Contracts.Messaging.V1.Entities;
using System.Runtime.Serialization;

namespace Contracts.Messaging.V1.Commands.VariableReceiptCommands
{
    public struct UpdateVariableReceiptCommand(VariableReceipt receipt, IEnumerable<VariableReceiptItem> receiptItems) : ICommand
    {
        [IgnoreDataMember]
        public string RoutingKey { get; set; } = receipt.Id.ToString();

        [IgnoreDataMember]
        public DateTime CommandCreatedDate { get; set; } = DateTime.UtcNow;

        [DataMember(Order = 1)]
        public VariableReceipt Receipt { get; set; } = receipt;

        [DataMember(Order = 2)]
        public IEnumerable<VariableReceiptItem> ReceiptItems { get; set; } = receiptItems;
    }
}
