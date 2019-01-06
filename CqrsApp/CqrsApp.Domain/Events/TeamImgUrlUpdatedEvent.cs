using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.Events
{
    public class TeamImgUrlUpdatedEvent : DomainEvent
    {
        public string ImgUrl { get; set; }
        public TeamImgUrlUpdatedEvent(string imgUrl)
        {
            this.ImgUrl = imgUrl;
        }
    }
}
