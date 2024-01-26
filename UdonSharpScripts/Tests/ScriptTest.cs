
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class ScriptTest : UdonSharpBehaviour
{
    void Start()
    {
        InteractionText = "Text";
        VRCPickup linkedPickup = transform.GetComponent<VRCPickup>();

        linkedPickup.orientation = VRC_Pickup.PickupOrientation.Any;
        linkedPickup.pickupable = true;
        linkedPickup.InteractionText = "Text";
        linkedPickup.UseText = "Text";
        linkedPickup.AutoHold = VRC_Pickup.AutoHoldMode.AutoDetect;
        //VRCPlayerApi player = linkedPickup.currentLocalPlayer;
        bool held = linkedPickup.IsHeld;
        linkedPickup.Drop();
    }

    public override void Interact()
    {
        base.Interact();
    }

    public override void OnPickup()
    {
        base.OnPickup();
    }

    public override void OnDrop()
    {
        base.OnDrop();
    }

    public override void OnPickupUseDown()
    {
        base.OnPickupUseDown();
    }

    public override void OnPickupUseUp()
    {
        base.OnPickupUseUp();
    }

}
