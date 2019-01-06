using SimpleCqrs.Commanding;

namespace CqrsApp.Domain.Commands
{
    public class CreateTeamCommand : ICommand
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public CreateTeamCommand(string name, string imageUrl)
        {
            this.Name = name;
            this.ImageUrl = imageUrl;
        }
    }
}
