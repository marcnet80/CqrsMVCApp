using SimpleCqrs.Commanding;
using System;

namespace CqrsApp.Domain.Commands
{
    public class DeleteTeamCommand : CommandWithAggregateRootId
    {
        public DeleteTeamCommand(Guid id)
        {
            this.AggregateRootId = id;
        }
    }
}
