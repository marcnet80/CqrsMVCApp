using SimpleCqrs.Commanding;
using System;

namespace CqrsApp.Domain.Commands
{
    public class UpdateTeamCommand : CommandWithAggregateRootId
    {
        public UpdateTeamCommand(Guid id, string name , string imgUrl)
        {
            this.AggregateRootId = id;
            this.Name = name;
            this.ImageUrl = imgUrl;
        }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
