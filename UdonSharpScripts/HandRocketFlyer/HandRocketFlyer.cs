using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff
{
    public class HandRocketFlyer : UdonSharpBehaviour
    {

        bool isActive = false;


        public override void OnPickupUseDown()
        {
            isActive = true;
        }

        public override void OnPickupUseUp()
        {
            isActive = false;
        }

        private void FixedUpdate()
        {
            if (isActive)
            {
                Networking.LocalPlayer.SetVelocity(Vector3.ClampMagnitude(Networking.LocalPlayer.GetVelocity() + transform.forward, 50));
            }
        }
    }
}