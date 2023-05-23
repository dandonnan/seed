namespace Seed.Unity.UI
{
    using System;
    using Seed.Unity.Extensions;
    using Seed.Unity.Input;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class Modal : MonoBehaviour
    {
        [Header("Main")]
        public TMP_Text Title;

        public TMP_Text Message;

        [Header("Positive")]
        public TMP_Text PositiveText;

        public Image PositiveIcon;

        [Header("Positive")]
        public TMP_Text NegativeText;

        public Image NegativeIcon;

        public event ModalVisibility Shown;

        public event ModalVisibility Hidden;

        public delegate void ModalVisibility();

        private bool canClose;

        private bool canCloseNegative;

        private Action closeAction;

        private void LateUpdate()
        {
            if (InputManager.Menu.South.WasCapturedThisFrame() && canClose)
            {
                Close(true);
            }

            if (InputManager.Menu.East.WasCapturedThisFrame() && canCloseNegative)
            {
                Close();
            }
        }

        public void Show(ModalSettings settings)
        {
            canClose = !settings.PreventClose;

            canCloseNegative = !string.IsNullOrWhiteSpace(settings.DeclinePrompt);

            SetText(settings.Title, settings.Message);

            if (canCloseNegative)
            {
                ShowNegativePrompt(settings.DeclinePrompt);
            }
            else
            {
                HideNegativePrompt();
            }

            if (string.IsNullOrWhiteSpace(settings.AcceptPrompt))
            {
                HidePositivePrompt();
            }
            else
            {
                closeAction = settings.AcceptAction;

                ShowPositivePrompt(settings.AcceptPrompt);
            }

            Open();
        }

        private void SetText(string title, string message)
        {
            Title.text = title;
            Message.text = message;
        }

        private void ShowPositivePrompt(string text)
        {
            PositiveText.text = text;

            ShowPrompt(PositiveText, PositiveIcon);
        }

        private void ShowNegativePrompt(string text)
        {
            NegativeText.text = text;

            ShowPrompt(NegativeText, NegativeIcon);
        }

        private void HidePositivePrompt()
        {
            HidePrompt(PositiveText, PositiveIcon);
        }

        private void HideNegativePrompt()
        {
            HidePrompt(NegativeText, NegativeIcon);
        }

        private void ShowPrompt(TMP_Text text, Image icon)
        {
            text.gameObject.SetActive(true);
            icon.gameObject.SetActive(true);
        }

        private void HidePrompt(TMP_Text text, Image icon)
        {
            text.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
        }

        private void Open()
        {
            gameObject.SetActive(true);

            Shown?.Invoke();
        }

        private void Close(bool doAction = false)
        {
            Hidden?.Invoke();

            gameObject.SetActive(false);

            if (doAction)
            {
                closeAction?.Invoke();
                closeAction = null;
            }
        }
    }
}