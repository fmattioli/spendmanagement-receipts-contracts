namespace Contracts.Messaging.V1.Entities
{
    public class RecurringReceipt(Guid id, Category category, string? establishmentName, DateTime dateInitialRecurrence, DateTime dateEndRecurrence, decimal recurrenceTotalPrice, string? observation)
    {
        public Guid Id { get; set; } = id;
        public Category Category { get; set; } = category;
        public string? EstablishmentName { get; set; } = establishmentName;
        public DateTime DateInitialRecurrence { get; set; } = dateInitialRecurrence;
        public DateTime DateEndRecurrence { get; set; } = dateEndRecurrence;
        public decimal RecurrenceTotalPrice { get; set; } = recurrenceTotalPrice;
        public string? Observation { get; set; } = observation;
    }
}
