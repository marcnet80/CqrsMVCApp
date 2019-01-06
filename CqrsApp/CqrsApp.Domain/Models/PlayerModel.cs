using CqrsApp.Domain.Events;
using SimpleCqrs.Domain;
using System;

namespace CqrsApp.Domain.Models
{
    public class PlayerModel : AggregateRoot
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PlayerNumber { get; set; }
        public string Country { get; set; }
        public DateTime DayBirth { get; set; }
        public string ImageUrl { get; set; }
        public Guid? TeamId { get; set; }

        //framework restriction
        public PlayerModel()
        {
        }

        public PlayerModel(Guid playerId, string name, string surname, int age, int playerNumber, string country, DateTime date, string imgUrl, Guid? teamId)
        {
            Apply(new PlayerCreatedEvent(playerId, name, surname, age, playerNumber, country, date, imgUrl, teamId));
        }

        protected void OnPlayerCreated(PlayerCreatedEvent createdEvent)
        {
            Id = createdEvent.AggregateRootId;
            Name = createdEvent.Name;
            Surname = createdEvent.Surname;
            Age = createdEvent.Age;
            Country = createdEvent.Country;
            DayBirth = createdEvent.DayBirth;
            ImageUrl = createdEvent.ImageUrl;
            PlayerNumber = createdEvent.PlayerNumber;
            TeamId = createdEvent.TeamId;
        }

        protected void OnPlayerNameUpdated(PlayerNameUpdatedEvent updatedEvent)
        {
            Name = updatedEvent.Name;
        }

        protected void OnPlayerSurnameUpdated(PlayerSurnameUpdatedEvent updatedEvent)
        {
            Surname = updatedEvent.Surname;
        }

        protected void OnPlayerAgeUpdated(PlayerAgeUpdatedEvent updatedEvent)
        {
            Age = updatedEvent.Age;
        }

        protected void OnPlayerNumberUpdated(PlayerNumberUpdatedEvent updatedEvent)
        {
            PlayerNumber = updatedEvent.PlayerNumber;
        }

        protected void OnPlayerCountryUpdated(PlayerCountryUpdatedEvent updatedEvent)
        {
            Country = updatedEvent.Country;
        }

        protected void OnPlayerDayBirthUpdated(PlayerDayBirthUpdatedEvent updatedEvent)
        {
            DayBirth = updatedEvent.DayBirth;
        }

        protected void OnPlayerImageUrlUpdated(PlayerImageUrlUpdatedEvent updatedEvent)
        {
            ImageUrl = updatedEvent.ImgUrl;
        }

        protected void OnPlayerTeamUpdated(PlayerTeamUpdatedEvent updatedEvent)
        {
            TeamId = updatedEvent.TeamId;
        }

        protected void OnPlayerDeleted(PlayerDeletedEvent updatedEvent)
        {
   
        }

        public void Delete(Guid id)
        {
            Apply(new PlayerDeletedEvent(id));
        }

        public void Update(string name, string surname, int age, int playerNumber, string country, DateTime date, string imgUrl, Guid? teamId)
        {
            if (!string.IsNullOrEmpty(name) && name != Name)
            {
                Apply(new PlayerNameUpdatedEvent(name));
            }
            if (!string.IsNullOrEmpty(surname) && surname != Surname)
            {
                Apply(new PlayerSurnameUpdatedEvent(surname));
            }
            if (age != Age)
            {
                Apply(new PlayerAgeUpdatedEvent(age));
            }
            if (playerNumber != PlayerNumber)
            {
                Apply(new PlayerNumberUpdatedEvent(playerNumber));
            }
            if (!string.IsNullOrEmpty(country) && country != Country)
            {
                Apply(new PlayerCountryUpdatedEvent(country));
            }
            if (date != DayBirth)
            {
                Apply(new PlayerDayBirthUpdatedEvent(date));
            }
            if (!string.IsNullOrEmpty(imgUrl) &&  imgUrl != ImageUrl)
            {
                Apply(new PlayerImageUrlUpdatedEvent(imgUrl));
            }
            if (teamId != null && teamId != TeamId)
            {
                Apply(new PlayerTeamUpdatedEvent(teamId));
            }
        }
    }
}
