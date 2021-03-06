using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.Client
{
    public class NewClientClaimEvent : Event
    {
        public int Id { get; }
        public string Type { get; }
        public string Value { get; }

        public NewClientClaimEvent(int id, string clientId, string type, string value)
            : base(EventTypes.Success)
        {
            Id = id;
            AggregateId = clientId;
            Type = type;
            Value = value;
        }
    }
}