namespace Seed.Unity.Extensions
{
    using Seed.Input;
    using UnityEngine;

    public static class ControllerColourExtensions
    {
        public static Color ToColor(this ControllerColours source)
        {
            Color colour;

            switch (source)
            {
                case ControllerColours.Black:
                    colour = Color.black;
                    break;

                case ControllerColours.White:
                    colour = Color.white;
                    break;

                case ControllerColours.LightBlue:
                    //153,217,234
                    colour = Color.cyan;
                    break;

                case ControllerColours.DarkBlue:
                    colour = Color.blue;
                    break;

                case ControllerColours.Purple:
                    colour = Color.magenta;
                    break;

                case ControllerColours.Red:
                    colour = Color.red;
                    break;

                case ControllerColours.Pink:
                    colour = new Color(1, 0.46f, 0.64f);
                    break;

                case ControllerColours.Peach:
                    colour = new Color(1, 0.68f, 0.79f);
                    break;

                case ControllerColours.Orange:
                    colour = new Color(1, 0.5f, 0);
                    break;

                case ControllerColours.Yellow:
                    colour = Color.yellow;
                    break;

                case ControllerColours.Cream:
                    colour = new Color(0.93f, 0.89f, 0.69f);
                    break;

                case ControllerColours.Green:
                    colour = Color.green;
                    break;

                case ControllerColours.Silver:
                    colour = new Color(0.76f, 0.76f, 0.76f);
                    break;

                case ControllerColours.Teal:
                    colour = new Color(0.25f, 0.5f, 0.5f);
                    break;

                case ControllerColours.Brown:
                    colour = new Color(0.72f, 0.47f, 0.34f);
                    break;

                default:
                    colour = Color.white;
                    break;
            }

            return colour;
        }
    }
}