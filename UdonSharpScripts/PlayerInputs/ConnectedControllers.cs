
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class ConnectedControllers : UdonSharpBehaviour
    {
        [SerializeField] InputField LinkedOutputField;
        const string newLine = "\n";

        void Start()
        {
            UpdateOutputs();
        }

        const string myControllerIdentifier = "d";

        public void UpdateOutputs()
        {
            string outputText = "";

            string[] controllers = Input.GetJoystickNames();



            for (int i = 0; i < controllers.Length; i++)
            {
                switch (controllers[i])
                {
                    case myControllerIdentifier:

                        break;
                }
            }

            outputText += $"IsUsingHandController = {InputManager.IsUsingHandController()}{newLine}{newLine}";

            if (controllers.Length == 0)
            {
                outputText += "No controllers connected";
            }
            else
            {
                outputText += $"Connected controllers at {System.DateTime.Now}:{newLine}";

                for (int i = 0; i < controllers.Length; i++)
                {
                    outputText += $"{i}:{newLine}{controllers[i]}{newLine}{newLine}";
                }
            }

            LinkedOutputField.text = outputText;
        }
    }
}