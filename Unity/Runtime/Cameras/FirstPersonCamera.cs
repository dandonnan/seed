namespace Seed.Unity.Cameras
{
    using Seed.Unity.Characters;
    using Seed.Unity.Input;
    using Seed.Unity.UI;
    using UnityEngine;

    public class FirstPersonCamera : MonoBehaviour
    {
        public Character Character;

        // todo: allow sensitivity to be changed in options, make it differ from mouse and gamepad

        private float sensitivityX = 400;

        private float sensitivityY = 400;

        private float xRotation;

        private float yRotation;

        private bool paused;

        private void Start()
        {
            Cursor.visible = false;

            paused = false;

            UIManager.Instance.Paused += OnPaused;
        }

        private void OnDestroy()
        {
            UIManager.Instance.Paused -= OnPaused;
        }

        private void LateUpdate()
        {
            if (paused == false)
            {
                UpdateCamera();
            }
        }

        public Vector2 GetRotation()
        {
            return new Vector2(xRotation, yRotation);
        }

        private void UpdateCamera()
        {
            Vector2 movement = InputManager.Player.RightStickMove.ReadValue<Vector2>();

            float x = movement.x * Time.deltaTime * sensitivityX;
            float y = movement.y * Time.deltaTime * sensitivityY;

            yRotation += x;
            xRotation -= y;

            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

            Character.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }

        private void OnPaused(bool paused)
        {
            this.paused = paused;
        }
    }
}
