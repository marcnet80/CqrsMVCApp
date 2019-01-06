using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.Events
{
    public class TeamUpdatedNameEvent : DomainEvent
    {
        public string Name { get; set; }
        public TeamUpdatedNameEvent(string name)
        {
            this.Name = name;
        }
    }
}
