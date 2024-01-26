using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class SyncedEvent : UdonSharpBehaviour
    {
        [SerializeField] Rigidbody BounceObject;
        Transform BounceTransform;
        Vector3 originalPosition;
        float bounceForce = 300;

        private void Start()
        {
            BounceTransform = BounceObject.transform;
            originalPosition = BounceTransform.position;
        }

        public override void Interact()
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(Bounce));
        }

        public void Bounce()
        {
            if (BounceTransform.position.y < originalPosition.y)
            {
                BounceTransform.position = new Vector3(originalPosition.x, BounceTransform.position.y, originalPosition.z);
                BounceObject.AddForce(Vector3.up * bounceForce);
            }
        }

    }
}