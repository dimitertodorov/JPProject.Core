using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.Client
{
    public class NewClientSecretEvent : Event
    {
        public int Id { get; }
        public string Type { get; }
        public string Description { get; }

        public NewClientSecretEvent(int id, string clientId, string type, string description)
            : base(EventTypes.Success)
        {
            Id = id;
            AggregateId = clientId;
            Type = type;
            Description = description;
        }
    }
}