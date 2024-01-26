using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff
{
    public class BringBackObject : UdonSharpBehaviour
    {
        Vector3 originalPosition;
        Quaternion originalRotation;
        Rigidbody linkedRigidbody;

        private void Start()
        {
            originalPosition = transform.position;
            originalRotation = transform.rotation;
            linkedRigidbody = transform.GetComponent<Rigidbody>();
        }

        public void BringBack()
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);

            transform.position = originalPosition;
            transform.rotation = originalRotation;

            if (linkedRigidbody != null)
            {
                linkedRigidbody.velocity = Vector3.zero;
                linkedRigidbody.angularVelocity = Vector3.zero;
            }
        }
    }
}