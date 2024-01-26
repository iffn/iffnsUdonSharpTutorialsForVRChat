
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PickupReset : UdonSharpBehaviour
{
    [SerializeField] VRC_Pickup LinkedPickup;
    Vector3 originalPosition;
    Quaternion originalRotation;

    public override void Interact()
    {
        LinkedPickup.Drop();

        Networking.SetOwner(Networking.LocalPlayer, LinkedPickup.gameObject);

        LinkedPickup.transform.localPosition = Vector3.zero;
        LinkedPickup.transform.localRotation = Quaternion.identity;
    }
}
