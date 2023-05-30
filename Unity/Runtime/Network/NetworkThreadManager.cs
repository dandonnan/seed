namespace Seed.Unity.Network
{
    using System;
    using System.Collections.Generic;

    public class NetworkThreadManager
    {
        protected static readonly List<Action> mainThreadActions = new List<Action>();

        protected static readonly List<Action> copiedThreadActions = new List<Action>();

        protected static bool executeOnMainThread = false;

        public static void ExecuteOnMainThread(Action action)
        {
            if (action != null)
            {
                lock (mainThreadActions)
                {
                    mainThreadActions.Add(action);
                    executeOnMainThread = true;
                }
            }
        }

        public static void Update()
        {
            if (executeOnMainThread == true)
            {
                copiedThreadActions.Clear();

                lock (mainThreadActions)
                {
                    copiedThreadActions.AddRange(mainThreadActions);
                    mainThreadActions.Clear();
                    executeOnMainThread = false;
                }

                for (int i = 0; i < copiedThreadActions.Count; i++)
                {
                    copiedThreadActions[i]();
                }
            }
        }
    }
}