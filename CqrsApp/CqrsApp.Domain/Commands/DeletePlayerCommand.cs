using SimpleCqrs.Commanding;
using System;

namespace CqrsApp.Domain.Commands
{
    public class DeletePlayerCommand : CommandWithAggregateRootId
    {
        public DeletePlayerCommand(Guid id)
        {
            this.AggregateRootId = id;
        }
    }
}
