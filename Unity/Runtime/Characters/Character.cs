namespace Seed.Unity.Characters
{
    using System;
    using Seed.AI;
    using Seed.Events;
    using Seed.Unity.AI;
    using UnityEngine;

    public class Character : MonoBehaviour
    {
        public IBrain Brain => brain;

        public bool IsPlayerControlled => Brain.PlayerControlled;

        public bool CanMove => canMove;

        [Header("Movement")]
        public float WalkSpeed;

        public float RunSpeed;

        public float CrouchSpeed;

        public Transform Orientation;

        [Header("Jumping")]
        public float JumpForce;

        public float AirMultiplier;

        [Header("Gravity")]
        public float CharacterHeight;

        public LayerMask GroundMask;

        public float GroundDrag;

        [Header("Objects")]
        public LayerMask KillMask;

        public bool StartPlayerControlled;

        protected CharacterBase characterBase;

        protected IBrain brain;

        protected bool canMove;

        private void Start()
        {
            Setup();
        }

        private void OnDestroy()
        {
            Destructor();
        }

        protected virtual void Setup()
        {
            characterBase = new CharacterBase(this);

            canMove = true;

            SetupBrains();

            EventManager.Instance.EventFired += OnEventFired;
        }

        protected virtual void Destructor()
        {
            EventManager.Instance.EventFired -= OnEventFired;
        }

        protected virtual void SetupBrains()
        {
            brain = new SeedDefaultBrain(characterBase);

            brain.Enable();
        }

        private void LateUpdate()
        {
            brain.Update();
        }

        protected virtual void OnEventFired(GameEvent gameEvent)
        {
            switch (gameEvent.EventId)
            {
                case SeedEvents.PauseGame:
                    HandleGamePaused();
                    break;

                case SeedEvents.ResumeGame:
                    HandleGameResumed();
                    break;

                default:
                    break;
            }
        }

        protected virtual void HandleGamePaused()
        {
            if (canMove)
            {
                canMove = false;

                brain.Pause();
            }
        }

        protected virtual void HandleGameResumed()
        {
            canMove = true;
            brain.Resume();
        }
    }
}