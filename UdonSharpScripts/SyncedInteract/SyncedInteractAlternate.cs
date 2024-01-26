using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class SyncedInteractAlternate : UdonSharpBehaviour
    {
        [SerializeField] GameObject ToggleObject;

        [SerializeField] TMPro.TextMeshPro infoBox;
        int numberOfActivationMessagesReceived = 0;
        int numberOfDeactivationMessagesReceived = 0;

        public override void Interact()
        {
            
            if (ToggleObject.activeSelf)
            {
                SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(SetInactive));
            }
            else
            {
                SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(SetActive));
            }
            
        }

        public void SetActive() //Function needs to be public for the Network Event call
        {
            ToggleObject.SetActive(true);
            numberOfActivationMessagesReceived++;
        }

        public void SetInactive() //Function needs to be public for the Network Event call
        {
            ToggleObject.SetActive(false);
            numberOfDeactivationMessagesReceived++;
        }

        private void Update()
        {
            //newLine = backslash n which is interpreted as a new line when showing the code in a text field
            string newLine = "\n";

            string outputText = "";

            outputText += "Owner = " + Networking.GetOwner(obj: gameObject).displayName + newLine;
            outputText += "Number of Activation messages received (local) = " + numberOfActivationMessagesReceived + newLine;
            outputText += "Number of Deactivation messages received (local) = " + numberOfDeactivationMessagesReceived;

            infoBox.text = outputText;
        }
    }
}