using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.Events
{
    public class PlayerAgeUpdatedEvent : DomainEvent
    {
        public int Age { get; set; }
        public PlayerAgeUpdatedEvent(int age)
        {
            this.Age = age;
        }
    }
}
