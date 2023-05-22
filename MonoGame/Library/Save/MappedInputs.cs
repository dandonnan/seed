namespace Seed.MonoGame.Save
{
    using Seed.MonoGame.Input;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using System.Text;

    public class MappedInputs
    {
        public List<InputBinding> Bindings;

        public MappedInputs()
        {
        }

        public string Serialise()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (Bindings != null)
            {
                foreach (InputBinding binding in Bindings)
                {
                    stringBuilder.Append($"{binding.Name}:{(int)binding.Key},{(int)binding.Button}.");
                }
            }

            return stringBuilder.ToString();
        }

        public void Deserialise(string serialisedInputs)
        {
            Bindings = new List<InputBinding>();

            if (serialisedInputs != null)
            {
                while (serialisedInputs.Length > 0)
                {
                    int indexOfCharacter = serialisedInputs.IndexOf(':');

                    string bindingName = serialisedInputs.Substring(0, indexOfCharacter);

                    serialisedInputs = serialisedInputs.Substring(indexOfCharacter + 1);

                    indexOfCharacter = serialisedInputs.IndexOf(',');

                    string keyCode = serialisedInputs.Substring(0, indexOfCharacter);

                    serialisedInputs = serialisedInputs.Substring(indexOfCharacter + 1);

                    indexOfCharacter = serialisedInputs.IndexOf('.');

                    string buttonCode = serialisedInputs.Substring(0, indexOfCharacter);

                    serialisedInputs = serialisedInputs.Substring(indexOfCharacter + 1);

                    Bindings.Add(new InputBinding
                    {
                        Name = bindingName,
                        Key = (Keys)int.Parse(keyCode),
                        Button = (Buttons)int.Parse(buttonCode)
                    });
                }
            }
        }
    }
}
