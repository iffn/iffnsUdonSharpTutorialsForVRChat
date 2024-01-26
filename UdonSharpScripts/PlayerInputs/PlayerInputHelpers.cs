using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class PlayerInputHelpers : UdonSharpBehaviour
    {
        VRCPlayerApi localPlayer;

        bool immobilized = false;

        private void Start()
        {
            localPlayer = Networking.LocalPlayer;
        }

        public void ToggleImmobilize()
        {
            immobilized = !immobilized;

            localPlayer.Immobilize(immobilized);
        }

        public void ExitStation()
        {
            localPlayer.TeleportTo(localPlayer.GetPosition(), localPlayer.GetRotation());
            localPlayer.Immobilize(false);
            immobilized = false;

            Debug.Log("Teleported");
        }
    }
}