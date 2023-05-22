namespace Seed.Unity.UI
{
    using Seed.Events;
    using Seed.Input;
    using Seed.Unity.Input;
    using UnityEngine;
    using UnityEngine.UI;

    public class ControllerIcon : MonoBehaviour
    {
        public ButtonType Button;

        private Image image;

        private void Start()
        {
            image = GetComponent<Image>();

            EventManager.Instance.EventFired += OnEventFired;

            ChangeSprite();
        }

        private void OnDestroy()
        {
            EventManager.Instance.EventFired -= OnEventFired;
        }

        private void OnEventFired(GameEvent gameEvent)
        {
            if (gameEvent.EventId == SeedEvents.InputDeviceChanged)
            {
                ChangeSprite();
            }
        }

        private void ChangeSprite()
        {
            image.sprite = IconLibrary.GetIcon(Button);
            image.SetNativeSize();
        }
    }
}