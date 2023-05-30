namespace Seed.Unity.Network
{
    using System;
    using UnityEngine;

    public class NetworkObjectMetadata
    {
        public string ObjectId { get; set; }

        public Vector3 Position { get; set; }

        public Quaternion Rotation { get; set; }

        public string Animation { get; set; }

        public event EventHandler StateChanged;

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                StateChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        protected string state;
    }
}