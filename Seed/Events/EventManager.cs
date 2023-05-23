namespace Seed.Events
{
    public class EventManager
    {
        public event GameEventHandler EventFired;

        public delegate void GameEventHandler(GameEvent gameEvent);

        private static EventManager instance;

        private EventManager()
        {
        }

        public static EventManager Instance
        {
            get
            {
                SetupEventManagerIfNull();
                return instance;
            }
        }

        private static void SetupEventManagerIfNull()
        {
            if (instance == null)
            {
                instance = new EventManager();
            }
        }

        private void OnEventFired(GameEvent gameEvent)
        {
            EventFired?.Invoke(gameEvent);
        }

        public static void Initialise()
        {
            SetupEventManagerIfNull();
        }

        public static GameEventHandler Event
        {
            get
            {
                SetupEventManagerIfNull();
                return instance.EventFired;
            }
            set
            {
                instance.EventFired = value;
            }
        }

        public static void FireEvent(string eventId)
        {
            if (string.IsNullOrWhiteSpace(eventId) == false)
            {
                FireEvent(new GameEvent(eventId));
            }
        }

        public static void FireEvent(GameEvent gameEvent)
        {
            SetupEventManagerIfNull();

            instance.OnEventFired(gameEvent);
        }
    }
}