namespace Seed.Achievements
{
    public class Achievement
    {
        public string Id { get; set; }

        public bool Completed { get; set; }

        public int Target { get; set; }

        public int CurrentProgress { get; set; }

        public Achievement() { }

        public Achievement(string id)
            : this(id, 1)
        {
        }

        public Achievement(string id, int target)
        {
            Id = id;
            Completed = false;
            Target = target;
            CurrentProgress = 0;
        }
    }
}
