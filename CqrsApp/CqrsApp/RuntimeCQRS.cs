using SimpleCqrs;
using SimpleCqrs.Eventing;
using SimpleCqrs.EventStore.SqlServer;
using SimpleCqrs.Unity;
using System.Configuration;

namespace CqrsApp
{
    public class RuntimeCQRS : SimpleCqrsRuntime<UnityServiceLocator>
    {
        protected override IEventStore GetEventStore(SimpleCqrs.IServiceLocator serviceLocator)
        {
            var configuration = new SqlServerConfiguration(ConfigurationManager.ConnectionStrings["EventStore"].ConnectionString);
            return new SqlServerEventStore(configuration, new SimpleCqrs.EventStore.SqlServer.Serializers.JsonDomainEventSerializer());
        }
    }
}