using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.Events
{
    public class PlayerTeamUpdatedEvent : DomainEvent
    {
        public System.Guid? TeamId { get; set; }
        public PlayerTeamUpdatedEvent(System.Guid? id)
        {
            this.TeamId = id;
        }
    }
}
