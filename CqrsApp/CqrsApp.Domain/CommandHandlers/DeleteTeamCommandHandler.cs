using CqrsApp.Domain.Commands;
using CqrsApp.Domain.Models;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace CqrsApp.Domain.CommandHandlers
{
    public class DeleteTeamCommandHandler : AggregateRootCommandHandler<DeleteTeamCommand, TeamModel>
    {
        protected IDomainRepository domainRepository;

        public DeleteTeamCommandHandler(IDomainRepository repository)
        {
            domainRepository = repository;
        }

        public override void Handle(DeleteTeamCommand command, TeamModel domain)
        {
            domain.Delete(command.AggregateRootId);
        }
    }
}
