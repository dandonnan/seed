namespace Seed.Unity.UI
{
    using Seed.Events;
    using TMPro;
    using UnityEngine;

    public class ControllerIconText : MonoBehaviour
    {
        private const string spriteFormat = "<sprite name=\"{0}\">";

        public TMP_Text Text;

        private string currentString;

        private string originalString;

        private void Start()
        {
            EventManager.Instance.EventFired += OnEventFired;

            originalString = Text.text;
            currentString = Text.text;

            ChangeIcon();
        }

        private void OnDestroy()
        {
            EventManager.Instance.EventFired -= OnEventFired;
        }

        private void OnEventFired(GameEvent gameEvent)
        {
            if (gameEvent.EventId == SeedEvents.InputDeviceChanged)
            {
                ChangeIcon();
            }
        }

        private void LateUpdate()
        {
            if (Text.text != currentString)
            {
                originalString = Text.text;
                currentString = Text.text;
                ChangeText();
            }
        }

        private void ChangeText()
        {
            string newString = originalString;

            while (newString.Contains("{ICON_"))
            {
                string instance = newString.Substring(newString.IndexOf("{ICON_") + 1);
                instance = instance.Substring(0, instance.IndexOf("}"));

                string iconName = string.Format(spriteFormat, IconLibrary.GetIcon(instance));

                newString = newString.Replace($"{{{instance}}}", iconName);
            }

            Text.text = newString;
            currentString = newString;
        }

        private void ChangeIcon()
        {
            Text.spriteAsset = IconLibrary.GetSpriteAsset();
            ChangeText();
        }
    }
}