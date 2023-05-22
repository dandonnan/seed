namespace Seed.Unity.UI
{
    public class UIManager
    {
        public static Modal Modal => instance.modal;

        public static bool ModalShowing => instance.modalShowing;

        //public static PauseMenu PauseMenu => instance.pauseMenu;

        public static bool Blocked => instance.blocked;

        public static UIManager Instance => instance;

        public event Pause Paused;

        public delegate void Pause(bool paused);

        private static UIManager instance;

        private Modal modal;

        //private PauseMenu pauseMenu;

        private bool blocked;

        private bool modalShowing;

        private UIManager(Modal modal)
        {
            instance = this;

            this.modal = modal;
            //this.pauseMenu = pauseMenu;

            if (this.modal != null)
            {
                this.modal.Shown += () => modalShowing = true;

                this.modal.Hidden += () => modalShowing = false;
            }

            /*if (this.pauseMenu != null)
            {
                this.pauseMenu.Shown += PauseGame;

                this.pauseMenu.Hidden += ResumeGame;
            } */
        }

        public static void Initialise(Modal modal)
        {
            new UIManager(modal);
        }

        public static void Block()
        {
            instance.blocked = true;
        }

        public static void Release()
        {
            instance.blocked = false;
        }

        private void PauseGame()
        {
            Paused?.Invoke(true);
        }

        private void ResumeGame()
        {
            Paused?.Invoke(false);
        }
    }
}