using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class InteractionBetweenScripts : UdonSharpBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI InfoBox;
        [SerializeField] PlayerSelector LinkedPlayerSelector;

        //newLine = backslash n which is interpreted as a new line when showing the code in a text field
        string newLine = "\n";

        private void Update()
        {
            string outputText = "";
            
            VRCPlayerApi linkedPlayer = LinkedPlayerSelector.selectedPlayer;

            if (linkedPlayer == null) linkedPlayer = Networking.LocalPlayer;

            outputText = "Player " + linkedPlayer.playerId + ": " + linkedPlayer.displayName + newLine;

            InfoBox.text = outputText;
        }
    }
}