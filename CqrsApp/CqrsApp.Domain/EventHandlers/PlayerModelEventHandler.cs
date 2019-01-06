using CqrsApp.Domain.Events;
using CqrsApp.ReadModel.Concrete;
using CqrsApp.ReadModel.Entities;
using SimpleCqrs.Eventing;

namespace CqrsApp.Domain.EventHandlers
{
    //write into database readmodel
    public class PlayerModelEventHandler : 
        IHandleDomainEvents<PlayerCreatedEvent>, 
        IHandleDomainEvents<PlayerNameUpdatedEvent>,
        IHandleDomainEvents<PlayerAgeUpdatedEvent>,
        IHandleDomainEvents<PlayerCountryUpdatedEvent>,
        IHandleDomainEvents<PlayerDayBirthUpdatedEvent>,
        IHandleDomainEvents<PlayerImageUrlUpdatedEvent>,
        IHandleDomainEvents<PlayerNumberUpdatedEvent>,
        IHandleDomainEvents<PlayerSurnameUpdatedEvent>,
        IHandleDomainEvents<PlayerTeamUpdatedEvent>,
        IHandleDomainEvents<PlayerDeletedEvent>
    {

        public void Handle(PlayerCreatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var team = context.Teams.Find(domainEvent.TeamId.Value);
                var player = new Player()
                {
                    Id = domainEvent.AggregateRootId,
                    Name = domainEvent.Name,
                    Surname = domainEvent.Surname,
                    PlayerNumber = domainEvent.PlayerNumber,
                    Age = domainEvent.Age,
                    Country = domainEvent.Country,
                    DayBirth = domainEvent.DayBirth,
                    ImageUrl = domainEvent.ImageUrl,
                    Team = team
                };
                context.Players.Add(player);
                context.SaveChanges();
            }
        }

        public void Handle(PlayerNameUpdatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var player = context.Players.Find(domainEvent.AggregateRootId);
                player.Name = domainEvent.Name;
                context.SaveChanges();
            }
        }

        public void Handle(PlayerAgeUpdatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var player = context.Players.Find(domainEvent.AggregateRootId);
                player.Age = domainEvent.Age;
                context.SaveChanges();
            }
        }

        public void Handle(PlayerCountryUpdatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var player = context.Players.Find(domainEvent.AggregateRootId);
                player.Country = domainEvent.Country;
                context.SaveChanges();
            }
        }

        public void Handle(PlayerDayBirthUpdatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var player = context.Players.Find(domainEvent.AggregateRootId);
                player.DayBirth = domainEvent.DayBirth;
                context.SaveChanges();
            }
        }

        public void Handle(PlayerImageUrlUpdatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var player = context.Players.Find(domainEvent.AggregateRootId);
                player.ImageUrl = domainEvent.ImgUrl;
                context.SaveChanges();
            }
        }

        public void Handle(PlayerNumberUpdatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var player = context.Players.Find(domainEvent.AggregateRootId);
                player.PlayerNumber = domainEvent.PlayerNumber;
                context.SaveChanges();
            }
        }

        public void Handle(PlayerSurnameUpdatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var player = context.Players.Find(domainEvent.AggregateRootId);
                player.Surname = domainEvent.Surname;
                context.SaveChanges();
            }
        }

        public void Handle(PlayerTeamUpdatedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var player = context.Players.Find(domainEvent.AggregateRootId);
                var team = context.Teams.Find(domainEvent.TeamId.Value);
                player.Team = team;
                context.SaveChanges();
            }
        }

        public void Handle(PlayerDeletedEvent domainEvent)
        {
            using (var context = new EFContext())
            {
                var player = context.Players.Find(domainEvent.AggregateRootId);
                context.Players.Remove(player);
                context.SaveChanges();
            }
        }
    }
}
