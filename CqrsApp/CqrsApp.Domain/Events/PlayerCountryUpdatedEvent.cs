using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.Events
{
    public class PlayerCountryUpdatedEvent : DomainEvent
    {
        public string Country { get; set; }
        public PlayerCountryUpdatedEvent(string country)
        {
            this.Country = country;
        }
    }
}
