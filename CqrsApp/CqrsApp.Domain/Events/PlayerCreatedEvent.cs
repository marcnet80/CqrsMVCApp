using SimpleCqrs.Eventing;
using System;

namespace CqrsApp.Domain.Events
{
    public class PlayerCreatedEvent: DomainEvent
    {
        public PlayerCreatedEvent(Guid playerId, string name,string surname, int age, int playerNumber, string country, DateTime date, string imgUrl, Guid? teamId)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.AggregateRootId = playerId;
            this.PlayerNumber = playerNumber;
            this.Country = country;
            this.DayBirth = date;
            this.ImageUrl = imgUrl;
            this.TeamId = teamId;
        }

        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PlayerNumber { get; set; }
        public string Country { get; set; }
        public DateTime DayBirth { get; set; }
        public string ImageUrl { get; set; }
        public Guid? TeamId { get; set; }
    }
}
