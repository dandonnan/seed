namespace Seed.AI
{
    public interface IBrain
    {
        bool Enabled { get; }

        bool UsesNetwork { get; }

        bool PlayerControlled { get; }

        void Dispose();

        void Enable();

        void Disable();

        void Pause();

        void Resume();

        void SetSpeed(float speed);

        string GetState();

        void Update();
    }
}