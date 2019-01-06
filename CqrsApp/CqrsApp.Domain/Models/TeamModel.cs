using CqrsApp.Domain.Events;
using SimpleCqrs.Domain;
using System;

namespace CqrsApp.Domain.Models
{
    public class TeamModel : AggregateRoot
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }


        public TeamModel()
        {
        }

        public TeamModel(Guid id,string name, string imgUrl)
        {
            Apply(new TeamCreatedEvent(id, name, imgUrl));
        }

        public void UpdateModel(Guid aggregateRootId, string name, string imageUrl)
        {
            if (!string.IsNullOrEmpty(name) && name != Name)
            {
                Apply(new TeamUpdatedNameEvent(name));
            }
            if (!string.IsNullOrEmpty(imageUrl) &&  imageUrl != ImgUrl)
            {
                Apply(new TeamImgUrlUpdatedEvent(imageUrl));
            }
        }

        public void Delete(Guid aggregateRootId)
        {
            Apply(new TeamDeletedEvent(aggregateRootId));
        }

        protected void OnTeamDeleted(TeamDeletedEvent @event)
        {

        }

        protected void OnTeamUpdatedName(TeamUpdatedNameEvent @event)
        {
            Name = @event.Name;
        }

        protected void OnTeamImgUrlUpdated(TeamImgUrlUpdatedEvent @event)
        {
            ImgUrl = @event.ImgUrl;
        }

        protected void OnTeamCreated(TeamCreatedEvent @event)
        {
            this.Id = @event.AggregateRootId;
            this.Name = @event.Name;
            this.ImgUrl = @event.ImageUrl;
        }

    }
}
