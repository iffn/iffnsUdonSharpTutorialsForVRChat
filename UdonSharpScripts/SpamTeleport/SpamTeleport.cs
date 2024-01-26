using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]
    public class SpamTeleport : UdonSharpBehaviour
    {
        //Settings
        [SerializeField] Transform EndPoint;
        float transitionTime = 3;

        //Runtime variables
        Vector3 startPosition;
        bool teleporting = false;

        private void Start()
        {
            startPosition = transform.position;
        }

        private void Update()
        {
            //Moving the teleporter
            float lerpValue = Time.time % (transitionTime * 2) / transitionTime;
            if (lerpValue > 1) lerpValue = 2 - lerpValue;

            transform.position = Vector3.Lerp(a: startPosition, b: EndPoint.position, t: lerpValue);

            //Teleporting the player
            if (teleporting)
            {

                Networking.LocalPlayer.TeleportTo(
                    teleportPos: transform.position,
                    teleportRot: Networking.LocalPlayer.GetRotation(),
                    teleportOrientation: VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint,
                    lerpOnRemote: true);

                /*
                Networking.LocalPlayer.TeleportTo(
                    teleportPos: transform.position,
                    teleportRot: Networking.LocalPlayer.GetRotation(),
                    teleportOrientation: VRC_SceneDescriptor.SpawnOrientation.AlignRoomWithSpawnPoint,
                    lerpOnRemote: true);
                */
            }
        }

        private void FixedUpdate()
        {
            //Resetting the velocity every phyics update helps reduce corner case issues with pens for example
            if(teleporting) Networking.LocalPlayer.SetVelocity(Vector3.zero);
        }

        public override void Interact()
        {
            teleporting = true;
        }

        public override void InputJump(bool value, UdonInputEventArgs args)
        {
            teleporting = false;
        }

        public override void InputMoveHorizontal(float value, UdonInputEventArgs args)
        {
            teleporting = false;
        }

        public override void InputMoveVertical(float value, UdonInputEventArgs args)
        {
            teleporting = false;
        }

    }
}