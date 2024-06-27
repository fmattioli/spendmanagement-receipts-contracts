using Contracts.Messaging.Interfaces;
using Contracts.Messaging.V1.Entities;
using System.Runtime.Serialization;

namespace Contracts.Messaging.V1.Commands.VariableReceiptCommands
{
    [DataContract]
    public struct CreateVariableReceiptCommand(VariableReceipt receipt, IEnumerable<VariableReceiptItem> receiptItems) : ICommand
    {
        [IgnoreDataMember]
        public string RoutingKey { get; set; } = receipt.Id.ToString();

        [IgnoreDataMember]
        public DateTime CommandCreatedDate { get; set; } = DateTime.UtcNow;

        [DataMember(Order = 1)]
        public VariableReceipt Receipt { get; set; } = receipt;

        [DataMember(Order = 2)]
        public IEnumerable<VariableReceiptItem> ReceiptItems { get; set; } = receiptItems;

        public readonly void VerifyIfItIsNecessaryApplyDiscountsBasedOnReceiptItem()
        {
            var makeDiscountBasedOnReceiptItems = ReceiptItems.Any(x => x.ItemDiscount != 0.0M);

            if (makeDiscountBasedOnReceiptItems)
            {
                var totalDiscounts = ReceiptItems.Sum(x => x.ItemDiscount);
                Receipt.Discount = totalDiscounts;
            }
        }

        public readonly void ProvideDiscountOnReceiptItemTotalPrice()
        {
            foreach (var item in ReceiptItems)
            {
                item.TotalPrice = item.Quantity * item.ItemPrice - item.ItemDiscount;
            }
        }

        public readonly void CalculateReceiptTotalPrice()
        {
            var totalReceiptWithOutDiscont = ReceiptItems.Sum(x => x.ItemPrice * x.Quantity);
            Receipt.Total = totalReceiptWithOutDiscont - Receipt.Discount;
        }
    }
}
