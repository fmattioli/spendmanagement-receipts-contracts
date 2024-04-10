using Contracts.Messaging.Interfaces;
using Contracts.Messaging.V1.Entities;
using System.Runtime.Serialization;

namespace Contracts.Messaging.V1.Events.CategoryEvents
{
    public struct UpdatedCategoryEvent(Category category) : IEvent
    {
        [IgnoreDataMember]
        public string RoutingKey { get; set; } = category.Id.ToString();

        [IgnoreDataMember]
        public DateTime EventCreatedDate { get; set; } = DateTime.UtcNow;

        [DataMember(Order = 1)]
        public Category Category { get; set; } = category;
    }
}
