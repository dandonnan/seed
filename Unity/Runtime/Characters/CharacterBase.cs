namespace Seed.Unity.Characters
{
    using System.Linq;
    using UnityEngine;

    public class CharacterBase
    {
        public Character Character => character;

        public bool IsGrounded => isGrounded;

        public bool IsCrouched => isCrouched;

        public Rigidbody Rigidbody => localRigidbody;

        public float CurrentMoveSpeed => moveSpeed;

        protected readonly Character character;

        protected float moveSpeed;

        protected Rigidbody localRigidbody;

        protected bool isGrounded;

        protected bool isCrouched;

        public CharacterBase(Character character)
        {
            this.character = character;

            localRigidbody = character.GetComponent<Rigidbody>();
            localRigidbody.freezeRotation = true;
        }

        protected virtual Character GetCharacterClosestToPosition(Vector3 position)
        {
            Character[] characters = GameObject.FindGameObjectsWithTag("")
                                               .Select(c => c.GetComponent<Character>())
                                               .ToArray();

            Character closest = null;

            float closestDistance = Mathf.Infinity;

            foreach (Character character in characters)
            {
                Vector3 distance = position - this.character.transform.position;

                float currentDistance = distance.sqrMagnitude;

                if (currentDistance < closestDistance && distance != Vector3.zero)
                {
                    closest = character;
                    closestDistance = currentDistance;
                }
            }

            return closest;
        }

        protected virtual bool IsCollidableObjectInRange(float range)
        {
            bool collided = false;

            if (Physics.Raycast(new Ray(character.transform.position, character.transform.TransformDirection(Vector3.forward)), out RaycastHit raycastHit))
            {
                if (raycastHit.distance < range)
                {
                    collided = true;
                }
            }

            return collided;
        }

        protected virtual void CheckMovementState()
        {
            if (isGrounded)
            {
                // todo: walk speed
                moveSpeed = isCrouched ? character.CrouchSpeed : character.RunSpeed;
                character.Brain.SetSpeed(moveSpeed);
            }
        }

        public virtual void HandlePhysics()
        {
            isGrounded = IsTouchingMask(character.GroundMask, 0.2f);

            CheckMovementState();

            localRigidbody.drag = isGrounded ? character.GroundDrag : 0;

            if (IsTouchingMask(character.KillMask))
            {
                // todo: kill
            }
        }

        protected virtual bool IsTouchingMask(LayerMask mask, float playerOffset = 0f)
        {
            return Physics.Raycast(character.transform.position, Vector3.down, character.CharacterHeight * 0.5f + playerOffset, mask);
        }

        public virtual bool TryJump()
        {
            if (isGrounded)
            {
                isCrouched = false;

                localRigidbody.velocity = new Vector3(localRigidbody.velocity.x, 0, localRigidbody.velocity.z);
                localRigidbody.AddForce(character.transform.up * character.JumpForce, ForceMode.Impulse);

                return true;
            }

            return false;
        }

        public virtual bool TryToggleCrouch(out bool crouched)
        {
            if (isGrounded)
            {
                isCrouched = !isCrouched;

                crouched = isCrouched;

                return true;
            }

            crouched = isCrouched;

            return false;
        }

        public virtual void ApplySpeedLimit()
        {
            Vector3 velocity = new Vector3(localRigidbody.velocity.x, 0, localRigidbody.velocity.z);

            if (velocity.magnitude > moveSpeed)
            {
                Vector3 maxVelocity = velocity.normalized * moveSpeed;
                localRigidbody.velocity = new Vector3(maxVelocity.x, localRigidbody.velocity.y, maxVelocity.z);
            }
        }
    }
}