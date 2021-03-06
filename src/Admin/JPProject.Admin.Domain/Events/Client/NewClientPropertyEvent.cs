using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.Client
{
    public class NewClientPropertyEvent : Event
    {
        public int Id { get; }
        public string Key { get; }
        public string Value { get; }

        public NewClientPropertyEvent(int id, string clientId, string key, string value)
            : base(EventTypes.Success)
        {
            Id = id;
            AggregateId = clientId;
            Key = key;
            Value = value;
        }
    }

}