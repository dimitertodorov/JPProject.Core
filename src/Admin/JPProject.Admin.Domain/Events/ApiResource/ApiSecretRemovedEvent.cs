using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.ApiResource
{
    public class ApiSecretRemovedEvent : Event
    {
        public string ResourceName { get; }

        public ApiSecretRemovedEvent(int id, string resourceName)
        {
            AggregateId = id.ToString();
            ResourceName = resourceName;
        }
    }
}