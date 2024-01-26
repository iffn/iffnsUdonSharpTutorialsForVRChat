using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class PlayerList : UdonSharpBehaviour
    {
        VRCPlayerApi[] vrcPlayers;
        [SerializeField] TMPro.TextMeshProUGUI infoBox;

        //newLine = backslash n which is interpreted as a new line when showing the code in a text field
        string newLine = "\n";

        private void Update()
        {
            string outputText = "";

            int numberOfPlayers = VRCPlayerApi.GetPlayerCount();

            vrcPlayers = new VRCPlayerApi[numberOfPlayers];

            VRCPlayerApi.GetPlayers(vrcPlayers);

            outputText += "Players in world:" + newLine;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (vrcPlayers[i] == null) continue;
                outputText += "Player " + vrcPlayers[i].playerId + ": " + vrcPlayers[i].displayName + newLine;
            }

            infoBox.text = outputText;
        }
    }
}