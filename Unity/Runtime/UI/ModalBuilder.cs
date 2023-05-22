namespace Seed.Unity.UI
{
    using System;
    using Seed.Unity.Text;

    public class ModalBuilder
    {
        private readonly ModalSettings settings;

        private bool preventLocalisation;

        private ModalBuilder(string titleId, string messageId, bool preventLocalisation = false)
        {
            this.preventLocalisation = preventLocalisation;

            settings = new ModalSettings
            {
                Title = preventLocalisation ? titleId : Translations.Get(titleId),
                Message = preventLocalisation ? messageId : Translations.Get(messageId),
                PreventClose = false,
            };
        }

        public static ModalBuilder Create(string titleId, string messageId, bool preventLocalisation = false)
        {
            return new ModalBuilder(titleId, messageId, preventLocalisation);
        }

        public ModalBuilder WithOK()
        {
            settings.AcceptPrompt = Translations.Get("ModalOK");

            settings.PreventClose = false;

            return this;
        }

        public ModalBuilder WithAccept(string promptId, Action action)
        {
            settings.AcceptPrompt = preventLocalisation ? promptId : Translations.Get(promptId);
            settings.AcceptAction = action;

            settings.PreventClose = false;

            return this;
        }

        public ModalBuilder WithDecline(string promptId)
        {
            settings.DeclinePrompt = preventLocalisation ? promptId : Translations.Get(promptId);

            settings.PreventClose = false;

            return this;
        }

        public ModalBuilder PreventClose()
        {
            if (settings.AcceptAction != null || string.IsNullOrWhiteSpace(settings.DeclinePrompt) == false)
            {
                settings.PreventClose = true;
            }

            return this;
        }

        public ModalSettings Build()
        {
            return settings;
        }

        public ModalSettings BuildAndShow()
        {
            UIManager.Modal.Show(settings);

            return settings;
        }
    }
}