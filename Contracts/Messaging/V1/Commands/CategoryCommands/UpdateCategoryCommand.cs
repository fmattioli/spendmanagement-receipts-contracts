using Contracts.Messaging.Interfaces;
using Contracts.Messaging.V1.Entities;
using System.Runtime.Serialization;

namespace Contracts.Messaging.V1.Commands.CategoryCommands
{
    public struct UpdateCategoryCommand(Category category) : ICommand
    {
        [IgnoreDataMember]
        public string RoutingKey { get; set; } = category.Id.ToString();

        [IgnoreDataMember]
        public DateTime CommandCreatedDate { get; set; } = DateTime.UtcNow;

        [DataMember(Order = 1)]
        public Category Category { get; set; } = category;
    }
}
