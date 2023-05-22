namespace Seed.Unity.Extensions
{
    using System.Collections.Generic;
    using UnityEngine;

    public static class StringExtensions
    {
        public static Vector3 ToVector3(this string source)
        {
            float x = 0, y = 0, z = 0;

            try
            {
                List<float> parameters = source.GetParameters();

                x = parameters[0];
                y = parameters[1];
                z = parameters[2];
            }
            catch
            {
                Debug.Log("Could not parse vector");
            }

            return new Vector3(x, y, z);
        }

        public static Quaternion ToQuaternion(this string source)
        {
            float x = 0, y = 0, z = 0, w = 0;

            try
            {
                List<float> parameters = source.GetParameters();

                x = parameters[0];
                y = parameters[1];
                z = parameters[2];
                w = parameters[3];
            }
            catch
            {
                Debug.Log("Could not parse quaternion");
            }

            return new Quaternion(x, y, z, w);
        }

        private static List<float> GetParameters(this string source)
        {
            List<float> parameters = new List<float>();

            source = source.Replace("(", string.Empty);
            source = source.Replace(")", string.Empty);

            string[] list = source.Split(',');

            foreach (string str in list)
            {
                parameters.Add(float.Parse(str));
            }

            return parameters;
        }
    }
}