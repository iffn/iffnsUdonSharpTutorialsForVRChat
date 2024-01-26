using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class SetPlayerSettings : UdonSharpBehaviour
    {
        VRCPlayerApi player;

        void Start()
        {
            player = Networking.LocalPlayer;
        }

        public void ResetSettings()
        {
            player.SetGravityStrength(strength: 1);
            player.SetJumpImpulse(impulse: 3);
            player.SetRunSpeed(speed: 4);
            player.SetWalkSpeed(speed: 2);
            player.SetStrafeSpeed(speed: 2);
            player.SetVelocity(velocity: Vector3.zero);
            player.SetPlayerTag(tagName: "", tagValue: "");
            player.SetSilencedToTagged(level: 0, tagName: "", tagValue: "");
            player.ClearPlayerTags();
            player.ClearSilence();
            player.EnablePickups(enable: true);
            player.Immobilize(immobile: false);
            //player.UseLegacyLocomotion();
            //player.UseAttachedStation();

            //Not accesible
            //player.RestoreNamePlateColor();
            //player.RestoreNamePlateVisibility();
            //player.TakeOwnership(obj: gameObject);
            //player.SetInvisibleToTagged(invisible: false, tagName: "", tagValue: "");
            //player.ClearInvisible();
            //player.SetPickupInHand(pickup: null, hand: VRC_Pickup.PickupHand.Left);
            //player.SetNamePlateColor(col: Color.red);
            //player.SetNamePlateVisibility(flag: true);
        }

        bool immobilized = false;
        public void ToggleImmobilize()
        {
            immobilized = !immobilized;
            player.Immobilize(immobilized);
        }

        bool enablePickups = true;
        public void TogglePickups()
        {
            enablePickups = !enablePickups;
            player.EnablePickups(enablePickups);
        }

        public void FlyUpABit()
        {
            player.SetVelocity(Vector3.up * 3);
        }

        public void IncreaseWalkSpeed()
        {
            player.SetWalkSpeed(player.GetWalkSpeed() * 1.2f);
        }
        public void DecreaseWalkSpeed()
        {
            player.SetWalkSpeed(player.GetWalkSpeed() / 1.2f);
        }

        public void IncreaseRunSpeed()
        {
            player.SetRunSpeed(player.GetRunSpeed() * 1.2f);
        }
        public void DecreaseRunSpeed()
        {
            player.SetRunSpeed(player.GetRunSpeed() / 1.2f);
        }

        public void IncreaseStrafeSpeed()
        {
            player.SetStrafeSpeed(player.GetStrafeSpeed() * 1.2f);
        }
        public void DecreaseStrafeSpeed()
        {
            player.SetStrafeSpeed(player.GetStrafeSpeed() / 1.2f);
        }

        public void IncreaseGravityStrength()
        {
            player.SetGravityStrength(player.GetGravityStrength() * 1.2f);
        }
        public void DecreaseGravityStrength()
        {
            player.SetGravityStrength(player.GetGravityStrength() / 1.2f);
        }

        public void IncreaseJumpImpulse()
        {
            player.SetJumpImpulse(player.GetJumpImpulse() * 1.2f);
        }
        public void DecreaseJumpImpulse()
        {
            player.SetJumpImpulse(player.GetJumpImpulse() / 1.2f);
        }
    }
}