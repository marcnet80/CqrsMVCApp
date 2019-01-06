using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.Events
{
    public class PlayerSurnameUpdatedEvent : DomainEvent
    {
        public string Surname { get; set; }
        public PlayerSurnameUpdatedEvent(string surname)
        {
            this.Surname = surname;
        }
    }
}
