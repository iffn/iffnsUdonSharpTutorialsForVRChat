using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class PlayerInfo : UdonSharpBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI infoBox;
        [SerializeField] PlayerSelector LinkedPlayerSelector;

        //newLine = backslash n which is interpreted as a new line when showing the code in a text field
        string newLine = "\n";

        private void Update()
        {
            string infoLines = "";

            VRCPlayerApi player = LinkedPlayerSelector.selectedPlayer; ;
            if (player == null) player = Networking.LocalPlayer;

            infoLines += "Player identifier (Synced): " + newLine;
            infoLines += "Player ID: " + player.playerId + newLine;
            infoLines += "Player display name: " + player.displayName + newLine;
            infoLines += "Player is in VR: " + player.IsUserInVR() + newLine;
            infoLines += newLine;

            infoLines += "Player permissions (Synced): " + newLine;
            infoLines += "Player is Instance Owner: " + player.isInstanceOwner + newLine;
            infoLines += "Player is Master: " + player.isMaster + newLine;
            infoLines += "Player is Local: " + player.isLocal + newLine;
            infoLines += "Player is Moderator: Not exposed in U#" + newLine; //player.isModerator not exposed in U#
            infoLines += newLine;

            infoLines += "Player location (Synced): " + newLine;
            infoLines += "Player position: " + player.GetPosition() + newLine;
            infoLines += "Player Velocity: " + player.GetVelocity() + newLine;
            infoLines += "Player rotation as Euler angles: " + player.GetRotation().eulerAngles + newLine;
            infoLines += "Player is Grounded: " + player.IsPlayerGrounded() + newLine;
            infoLines += newLine;

            if (player == Networking.LocalPlayer)
            {

                infoLines += "Player idems held (Local): " + newLine;
                if (player.GetPickupInHand(VRC_Pickup.PickupHand.Left) != null) infoLines += "Player item left hand: " + player.GetPickupInHand(VRC_Pickup.PickupHand.Left).name + newLine;
                else infoLines += "No item in left hand" + newLine;
                if (player.GetPickupInHand(VRC_Pickup.PickupHand.Right) != null) infoLines += "Player item right hand: " + player.GetPickupInHand(VRC_Pickup.PickupHand.Right).name + newLine;
                else infoLines += "No item in right hand" + newLine;
                infoLines += newLine;

                infoLines += "Player locomotion settings (Local): " + newLine;
                infoLines += "Player Walk speed: " + player.GetWalkSpeed() + newLine;
                infoLines += "Player Run speed: " + player.GetRunSpeed() + newLine;
                infoLines += "Player Strave speed: " + player.GetStrafeSpeed() + newLine;
                infoLines += "Player Gravity strength: " + player.GetGravityStrength() + newLine;
                infoLines += "Player Jump impulse: " + player.GetJumpImpulse() + newLine;
                infoLines += newLine;

                infoLines += "Player tracking (Local): " + newLine;
                infoLines += "Player Tracking data Origin position: " + player.GetTrackingData(VRCPlayerApi.TrackingDataType.Origin).position + newLine;
                infoLines += "Player Tracking data Head position: " + player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position + newLine;
                infoLines += "Player Tracking data Left hand position: " + player.GetTrackingData(VRCPlayerApi.TrackingDataType.LeftHand).position + newLine;
                infoLines += "Player Tracking data Right hand position: " + player.GetTrackingData(VRCPlayerApi.TrackingDataType.RightHand).position + newLine;
            }
            else
            {
                infoLines += "Note: multiple settings cannot be displayed for non-local players";
            }

            infoBox.text = (infoLines);
        }
    }
}