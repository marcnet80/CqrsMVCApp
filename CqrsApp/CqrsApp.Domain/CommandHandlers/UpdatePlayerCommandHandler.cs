using CqrsApp.Domain.Commands;
using CqrsApp.Domain.Models;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace CqrsApp.Domain.CommandHandlers
{
    public class UpdatePlayerCommandHandler : AggregateRootCommandHandler<UpdatePlayerCommand, PlayerModel> 
    {
        protected IDomainRepository domainRepository;

        public UpdatePlayerCommandHandler(IDomainRepository repository)
        {
            domainRepository = repository;
        }

        public override void Handle(UpdatePlayerCommand command, PlayerModel domain)
        {
            domain.Update(command.Name, command.Surname, command.Age, command.PlayerNumber, command.Country, command.DayBirth, command.ImageUrl, command.TeamId);
        }
    }
}
