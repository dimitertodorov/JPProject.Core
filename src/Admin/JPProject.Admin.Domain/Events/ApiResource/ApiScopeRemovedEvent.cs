using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.ApiResource
{
    public class ApiScopeRemovedEvent : Event
    {
        public string ResourceName { get; }
        public string Name { get; }

        public ApiScopeRemovedEvent(int id, string resourceName, string name)
        {
            AggregateId = id.ToString();
            ResourceName = resourceName;
            Name = name;
        }
    }
}