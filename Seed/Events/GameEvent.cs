namespace Seed.Events
{
    public class GameEvent
    {
        public string EventId { get; set; }

        public object Value { get; set; }

        public GameEvent(string id)
        {
            EventId = id;
        }

        public GameEvent(string id, object value)
            : this(id)
        {
            Value = value;
        }
    }
}