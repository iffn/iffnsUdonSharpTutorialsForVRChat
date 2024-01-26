using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class SyncedInteract : UdonSharpBehaviour
    {
        [UdonSynced] bool ShouldBeActive = true;
        
        [SerializeField] GameObject ToggleObject;
        [SerializeField] TMPro.TextMeshProUGUI infoBox;

        int numberOfDeserializations = 0;
        int numberOfSuccesses = 0;
        int numberOfFailures = 0;
        int lastByteCount = 0;
        int byteCount = 0;

        //newLine = backslash n which is interpreted as a new line when showing the code in a text field
        string newLine = "\n";

        public override void Interact()
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            ShouldBeActive = !ShouldBeActive;

            ToggleObject.SetActive(ShouldBeActive);

            RequestSerialization();
        }

        public override void OnDeserialization()
        {
            ToggleObject.SetActive(ShouldBeActive);

            numberOfDeserializations++;
        }

        public override void OnPostSerialization(SerializationResult result)
        {
            if (result.success) numberOfSuccesses++;
            else numberOfFailures++;
            lastByteCount = result.byteCount;
            byteCount += result.byteCount;
        }

        private void Update()
        {
            string outputText = "";

            VRCPlayerApi owner = Networking.GetOwner(gameObject);
            outputText += "Owner: " + owner.playerId + ": " + owner.displayName;
            if (owner == Networking.LocalPlayer) outputText += " (You)";
            outputText += newLine;
            
            outputText += "Number of Deserializations (local) = " + numberOfDeserializations + newLine;
            outputText += "Number of successes = " + numberOfSuccesses + newLine;
            outputText += "Number of failures = " + numberOfFailures + newLine;
            outputText += "Last byte count = " + lastByteCount + newLine;
            outputText += "Byte count = : " + byteCount + newLine;

            infoBox.text = outputText;
        }
    }
}