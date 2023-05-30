namespace Seed.Unity.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Queue
    {
        protected readonly List<Action> queue;

        public Queue()
        {
            queue = new List<Action>();
        }

        public void Add(Action action)
        {
            queue.Add(action);
        }

        public void Clear()
        {
            queue.Clear();
        }

        public int Count()
        {
            return queue.Count;
        }

        public void ProcessNext()
        {
            if (queue.Count > 0)
            {
                Action action = queue.First();

                queue.Remove(action);

                action();
            }
        }
    }
}