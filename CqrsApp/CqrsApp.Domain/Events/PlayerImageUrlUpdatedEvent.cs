using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.Events
{
    public class PlayerImageUrlUpdatedEvent : DomainEvent
    {
        public string ImgUrl { get; set; }
        public PlayerImageUrlUpdatedEvent(string url)
        {
            this.ImgUrl = url;
        }
    }
}
