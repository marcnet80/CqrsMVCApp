using SimpleCqrs.Eventing;
using System;

namespace CqrsApp.Domain.Events
{
    public class PlayerDeletedEvent : DomainEvent
    {
        public PlayerDeletedEvent(Guid id)
        {
            this.AggregateRootId = id;
        }
    }
}
