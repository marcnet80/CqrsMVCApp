using SimpleCqrs.Eventing;
using System;

namespace CqrsApp.Domain.Events
{
    public class PlayerDayBirthUpdatedEvent : DomainEvent
    {
        public DateTime DayBirth { get; set; }
        public PlayerDayBirthUpdatedEvent(DateTime date)
        {
            this.DayBirth = date;
        }
    }
}
