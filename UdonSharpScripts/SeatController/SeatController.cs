using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class SeatController : UdonSharpBehaviour
    {
        [SerializeField] VRCStation Seat;
        [SerializeField] TMPro.TextMeshProUGUI InfoBox;

        bool playerSitting = false;
        VRCPlayerApi seatedPlayer;

        //newLine = backslash n which is interpreted as a new line when showing the code in a text field
        string newLine = "\n";

        public override void OnStationEntered(VRCPlayerApi player)
        {
            playerSitting = true;
            seatedPlayer = player;
        }

        public override void OnStationExited(VRCPlayerApi player)
        {
            playerSitting = false;
            seatedPlayer = null;
        }

        public override void Interact()
        {
            Networking.LocalPlayer.UseAttachedStation();
        }

        private void Update()
        {
            //Show debug info
            string infoLines = "";

            infoLines += "Can use station from station: " + Seat.canUseStationFromStation + newLine;
            infoLines += "Controls object: Not exposed in U#" + newLine; //Seat.controlsObject not exposed in U#
            infoLines += "Disable station exit: " + Seat.disableStationExit + newLine;
            infoLines += "Enabled: " + Seat.enabled + newLine;
            infoLines += "Game object name: " + Seat.gameObject.name + newLine;
            infoLines += "Player mobility: " + Seat.PlayerMobility + newLine;
            infoLines += "Seated: " + Seat.seated + newLine;
            infoLines += "Player sitting: " + playerSitting + newLine;

            if (seatedPlayer != null) infoLines += "Player seated: " + seatedPlayer.playerId + " " + seatedPlayer.displayName + newLine;
            else infoLines += "No player seated" + newLine;

            InfoBox.text = infoLines;
        }
    }
}