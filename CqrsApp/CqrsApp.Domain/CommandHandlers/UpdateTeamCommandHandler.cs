using CqrsApp.Domain.Commands;
using CqrsApp.Domain.Models;
using SimpleCqrs.Commanding;
using System;

namespace CqrsApp.Domain.CommandHandlers
{
    public class UpdateTeamCommandHandler : AggregateRootCommandHandler<UpdateTeamCommand, TeamModel>
    {
        public override void Handle(UpdateTeamCommand command, TeamModel domain)
        {
            domain.UpdateModel(command.AggregateRootId, command.Name, command.ImageUrl);            
        }
    }
}
