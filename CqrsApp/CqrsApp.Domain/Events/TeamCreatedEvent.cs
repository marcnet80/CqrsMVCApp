using SimpleCqrs.Eventing;
using System;

namespace CqrsApp.Domain.Events
{
    public class TeamCreatedEvent : DomainEvent
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public TeamCreatedEvent(Guid id,string name, string imageUrl)
        {
            this.AggregateRootId = id;
            this.Name = name;
            this.ImageUrl = imageUrl;
        }
    }
}
