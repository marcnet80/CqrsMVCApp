using CqrsApp.ReadModel.Entities;
using System.Data.Entity;

namespace CqrsApp.ReadModel.Concrete
{
    public class EventSourceContext : DbContext
    {
        public EventSourceContext() : base("name=EventStore")
        {
        }
    }
}
