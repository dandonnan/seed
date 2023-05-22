namespace Seed.State
{
    using Seed.Save;
    using System.Collections.Generic;

    public class CheckpointManager
    {
        private const string temporaryCheckpoint = "Session";

        private static CheckpointManager instance;

        private readonly Dictionary<string, Checkpoint> checkpoints;

        public delegate void CheckpointStateChanged();

        public event CheckpointStateChanged OnStateChanged;

        private CheckpointManager()
        {
            checkpoints = new Dictionary<string, Checkpoint>();

            instance = this;
        }

        public static CheckpointManager Initialise()
        {
            if (instance == null)
            {
                new CheckpointManager();
            }

            return instance;
        }

        public static void ResetForNewGame()
        {
            instance.checkpoints.Clear();
        }

        public static List<Checkpoint> GetCheckpointsForSave()
        {
            List<Checkpoint> checkpoints = new List<Checkpoint>();

            foreach (KeyValuePair<string, Checkpoint> checkpoint in instance.checkpoints)
            {
                if (checkpoint.Key.StartsWith(temporaryCheckpoint) == false)
                {
                    checkpoints.Add(checkpoint.Value);
                }
            }

            return checkpoints;
        }

        public static void SetCheckpoint(string name, string state)
        {
            instance.checkpoints.TryGetValue(name, out Checkpoint checkpoint);

            if (checkpoint != null)
            {
                checkpoint.State = state;
            }
            else
            {
                instance.checkpoints.Add(name, new Checkpoint
                {
                    Name = name,
                    State = state
                });
            }

            if (name.StartsWith(temporaryCheckpoint) == false)
            {
                SaveManager.Save();
            }

            instance.OnStateChanged?.Invoke();
        }

        public static void SetCheckpoint(string nameAndState)
        {
            int indexOfSeparator = nameAndState.IndexOf('.');

            if (indexOfSeparator > -1)
            {
                SetCheckpoint(nameAndState.Substring(0, indexOfSeparator), nameAndState.Substring(indexOfSeparator + 1));
            }
        }

        public static string GetCheckpoint(string name)
        {
            string state = null;

            instance.checkpoints.TryGetValue(name, out Checkpoint checkpoint);

            if (checkpoint != null)
            {
                state = checkpoint.State;
            }

            return state;
        }

        public static bool GetCheckpointFromState(string name)
        {
            bool checkpointAtState = false;

            int indexOfSeparator = name.IndexOf('.');

            if (indexOfSeparator > -1)
            {
                checkpointAtState = GetCheckpoint(name.Substring(0, indexOfSeparator), name.Substring(indexOfSeparator + 1));
            }

            return checkpointAtState;
        }

        public static bool GetCheckpoint(string name, string state)
        {
            bool checkpointAtState = false;

            instance.checkpoints.TryGetValue(name, out Checkpoint checkpoint);

            if (checkpoint != null && checkpoint.State == state)
            {
                checkpointAtState = true;
            }

            return checkpointAtState;
        }
    }
}
