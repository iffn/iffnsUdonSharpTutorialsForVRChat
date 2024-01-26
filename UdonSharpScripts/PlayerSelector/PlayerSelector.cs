using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Mozilla;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class PlayerSelector : UdonSharpBehaviour
    {
        [SerializeField] PlayerSelectionButton[] selectorButtons;
        [SerializeField] TMPro.TextMeshProUGUI infoBox;

        public VRCPlayerApi selectedPlayer;

        //newLine = backslash n which is interpreted as a new line when showing the code in a text field
        string newLine = "\n";

        string LogText = "";

        private void Start()
        {
            selectedPlayer = Networking.LocalPlayer;

            UpdateOutput();
        }

        void UpdateOutput()
        {
            string outputText = $"Selected player = {selectedPlayer.displayName}{newLine}{newLine}Logs:{newLine}{LogText}";

            infoBox.text = outputText;
        }

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            LogText += "Player " + player.playerId + " joined: " + player.displayName + newLine;

            foreach (PlayerSelectionButton button in selectorButtons)
            {
                if (button.gameObject.activeSelf) continue;

                button.Setup(player, this);
                button.gameObject.SetActive(true);

                break;
            }

            UpdateOutput();
        }

        public override void OnPlayerLeft(VRCPlayerApi player)
        {
            LogText += "Player " + player.playerId + " left: " + player.displayName + newLine;

            foreach (PlayerSelectionButton button in selectorButtons)
            {
                if (button.player != player) continue;

                button.gameObject.SetActive(false);

                break;
            }

            if (player == selectedPlayer) selectedPlayer = Networking.LocalPlayer;

            UpdateOutput();
        }

        public void SelectPlayer(VRCPlayerApi player)
        {
            selectedPlayer = player;

            LogText += "Activated player " + selectedPlayer.playerId + " : " + selectedPlayer.displayName;
            UpdateOutput();
        }
    }
}