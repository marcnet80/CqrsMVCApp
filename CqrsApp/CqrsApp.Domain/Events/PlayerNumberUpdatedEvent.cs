using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.Events
{
    public class PlayerNumberUpdatedEvent : DomainEvent
    {
        public int PlayerNumber { get; set; }
        public PlayerNumberUpdatedEvent(int number)
        {
            this.PlayerNumber = number;
        }
    }
}
