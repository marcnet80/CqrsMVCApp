using CqrsApp.Domain.Commands;
using CqrsApp.Domain.Models;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace CqrsApp.Domain.CommandHandlers
{
    public class CreatePlayerCommandHandler : CommandHandler<CreatePlayerCommand>
    {
       //EventStore
        protected IDomainRepository domainRepository;

        public CreatePlayerCommandHandler(IDomainRepository repository)
        {
            domainRepository = repository;
        }

        public override void Handle(CreatePlayerCommand command)
        {
            var domain = new PlayerModel(System.Guid.NewGuid(), command.Name, command.Surname, command.Age, command.PlayerNumber, command.Country, command.DayBirth, command.ImageUrl, command.TeamId);
            domainRepository.Save(domain);
        }
    }
}
