namespace Seed.Unity.AI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Seed.AI;
    using Seed.Unity.Characters;
    using UnityEngine;

    public class SeedDefaultBrain : IBrain
    {
        public bool Enabled { get; protected set; }

        public bool UsesNetwork => false;

        public bool PlayerControlled => false;

        protected readonly CharacterBase characterBase;

        protected readonly Character character;

        public SeedDefaultBrain(CharacterBase characterBase)
        {
            this.characterBase = characterBase;

            character = characterBase.Character;
        }

        public void Dispose()
        {
        }

        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }

        public void Pause()
        {
        }

        public void Resume()
        {
        }

        public string GetState()
        {
            return string.Empty;
        }

        public void SetSpeed(float speed)
        {
        }

        public void Update()
        {
        }
    }
}