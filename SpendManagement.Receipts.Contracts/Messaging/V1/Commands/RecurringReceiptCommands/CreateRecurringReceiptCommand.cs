using Contracts.Messaging.Interfaces;
using Contracts.Messaging.V1.Entities;
using System.Runtime.Serialization;

namespace Contracts.Messaging.V1.Commands.RecurringReceiptCommands
{
    public struct CreateRecurringReceiptCommand(RecurringReceipt recurringReceipt) : ICommand
    {
        [IgnoreDataMember]
        public string RoutingKey { get; set; } = recurringReceipt.Id.ToString();

        [IgnoreDataMember]
        public DateTime CommandCreatedDate { get; set; } = DateTime.UtcNow;

        [DataMember(Order = 1)]
        public RecurringReceipt RecurringReceipt { get; set; } = recurringReceipt;

    }
}
