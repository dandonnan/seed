namespace Seed.Unity.Menu
{
    using UnityEngine;

    public interface IMenuOptionUI
    {
        void SetText(string text);

        void SetText(string text, Color colour);

        void SetTextColour(Color colour);
    }
}