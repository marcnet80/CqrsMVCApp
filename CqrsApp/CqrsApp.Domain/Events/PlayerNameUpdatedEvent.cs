using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.Events
{
    public class PlayerNameUpdatedEvent : DomainEvent
    {
        public string Name { get; set; }
        public PlayerNameUpdatedEvent(string name)
        {
            this.Name = name;
        }
    }
}
