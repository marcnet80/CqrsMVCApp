using CqrsApp.Domain.Events;
using CqrsApp.ReadModel.Concrete;
using CqrsApp.ReadModel.Entities;
using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.EventHandlers
{
    public class TeamModelEventHandler : 
        IHandleDomainEvents<TeamCreatedEvent>,
        IHandleDomainEvents<TeamImgUrlUpdatedEvent>, 
        IHandleDomainEvents<TeamUpdatedNameEvent>,
        IHandleDomainEvents<TeamDeletedEvent>
    {
        public void Handle(TeamCreatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var team = new Team()
                {
                    Id = domainEvent.AggregateRootId,
                    Name = domainEvent.Name,
                    ImageUrl = domainEvent.ImageUrl
                };
                context.Teams.Add(team);
                context.SaveChanges();
            }
        }

        public void Handle(TeamImgUrlUpdatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var team = context.Teams.Find(domainEvent.AggregateRootId);
                team.ImageUrl = domainEvent.ImgUrl;
                context.SaveChanges();
            }
        }

        public void Handle(TeamUpdatedNameEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var team = context.Teams.Find(domainEvent.AggregateRootId);
                team.Name = domainEvent.Name;
                context.SaveChanges();
            }
        }

        public void Handle(TeamDeletedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var team = context.Teams.Find(domainEvent.AggregateRootId);
                context.Teams.Remove(team);
                context.SaveChanges();
            }
        }
    }
}
