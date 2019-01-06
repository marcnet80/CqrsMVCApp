using CqrsApp.Domain.Commands;
using CqrsApp.Domain.Models;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;
using System;

namespace CqrsApp.Domain.CommandHandlers
{
    public class CreateTeamCommandHandler : CommandHandler<CreateTeamCommand>
    {
        protected IDomainRepository domainRepository;

        public CreateTeamCommandHandler(IDomainRepository repository)
        {
            domainRepository = repository;
        }

        public override void Handle(CreateTeamCommand command)
        {
            var team = new TeamModel(Guid.NewGuid(), command.Name, command.ImageUrl);
            domainRepository.Save(team);
        }
    }
}
