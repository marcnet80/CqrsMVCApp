using SimpleCqrs.Eventing;
using System;

namespace CqrsApp.Domain.Events
{
    public class TeamDeletedEvent : DomainEvent
    {
        public TeamDeletedEvent(Guid id)
        {
            this.AggregateRootId = id;
        }
    }
}
