namespace Contracts.Messaging.V1.Entities
{
    public record RecurringReceipt(Guid Id,
        Guid UserId,
        Tenant Tenant,
        Category Category,
        string EstablishmentName,
        DateTime DateInitialRecurrence,
        DateTime DateEndRecurrence,
        decimal RecurrenceTotalPrice,
        string Observation)
    {
    }
}
