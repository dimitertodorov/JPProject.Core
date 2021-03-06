using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.Client
{
    public class ClientClonedEvent : Event
    {
        public string From { get; }
        public string To { get; }

        public ClientClonedEvent(string from, string to)
            : base(EventTypes.Success)
        {
            AggregateId = @from;
            From = @from;
            To = to;
        }
    }
}