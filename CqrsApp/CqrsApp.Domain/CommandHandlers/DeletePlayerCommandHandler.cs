using CqrsApp.Domain.Commands;
using CqrsApp.Domain.Models;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace CqrsApp.Domain.CommandHandlers
{
    public class DeletePlayerCommandHandler : AggregateRootCommandHandler<DeletePlayerCommand, PlayerModel>
    {
        protected IDomainRepository domainRepository;

        public DeletePlayerCommandHandler(IDomainRepository repository)
        {
            domainRepository = repository;
        }

        public override void Handle(DeletePlayerCommand command, PlayerModel model)
        {
            model.Delete(command.AggregateRootId);
        }
    }
}
