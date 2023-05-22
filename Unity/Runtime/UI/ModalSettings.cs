namespace Seed.Unity.UI
{
    using System;

    public class ModalSettings
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public string AcceptPrompt { get; set; }

        public Action AcceptAction { get; set; }

        public string DeclinePrompt { get; set; }

        public bool PreventClose { get; set; }
    }
}