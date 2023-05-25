namespace Seed.Save
{
    public class BaseControlsOptions
    {
        public bool InvertVertical { get; set; }

        public bool InvertHorizontal { get; set; }

        public bool AllowRumble { get; set; }

        public int MouseSensitivity { get; set; }

        public int LeftStickSensitivity { get; set; }

        public int RightStickSensitivity { get; set; }

        public virtual void SetToDefault()
        {
            InvertVertical = false;
            InvertHorizontal = false;
            AllowRumble = true;
            MouseSensitivity = 0;
            LeftStickSensitivity = 0;
            RightStickSensitivity = 0;
        }
    }
}
