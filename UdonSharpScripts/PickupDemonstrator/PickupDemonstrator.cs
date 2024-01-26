using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PickupDemonstrator : UdonSharpBehaviour
{
    [SerializeField] VRC_Pickup LinkedPickup;

    [SerializeField] TMPro.TextMeshProUGUI DebugField;
    [SerializeField] GameObject LocalToggle;
    string newLine = "\n";

    private void Update()
    {
        string debugText = "";

        debugText += "Runtime parameters:" + newLine;

        debugText += "IsHeld = " + LinkedPickup.IsHeld + newLine;

        if (LinkedPickup.currentPlayer != null)
        {
            debugText += $"currentPlayer = {LinkedPickup.currentPlayer.playerId}: {LinkedPickup.currentPlayer.displayName}" + newLine;
        }
        else
        {
            debugText += "currentPlayer = null" + newLine;
        }

        debugText += "currentHand = " + LinkedPickup.currentHand + newLine;

        debugText += newLine;
        debugText += "Settings:" + newLine;

        debugText += "MomentumTransferMethod = " + LinkedPickup.MomentumTransferMethod + newLine;
        debugText += "DisallowTheft = " + LinkedPickup.DisallowTheft + newLine;

        if (LinkedPickup.ExactGun != null)
        {
            debugText += "ExactGun = " + LinkedPickup.ExactGun.name + newLine;
        }
        else
        {
            debugText += "ExactGun = null" + newLine;
        }

        if (LinkedPickup.ExactGrip != null)
        {
            debugText += "ExactGrip = " + LinkedPickup.ExactGrip.name + newLine;
        }
        else
        {
            debugText += "ExactGrip = null" + newLine;
        }

        debugText += "allowManipulationWhenEquipped = " + LinkedPickup.allowManipulationWhenEquipped + newLine;
        debugText += "orientation = " + LinkedPickup.orientation + newLine;
        debugText += "AutoHold = " + LinkedPickup.AutoHold + newLine;
        debugText += "InteractionText = " + LinkedPickup.InteractionText + newLine;
        debugText += "UseText = " + LinkedPickup.UseText + newLine;
        debugText += "ThrowVelocityBoostMinSpeed = " + LinkedPickup.ThrowVelocityBoostMinSpeed + newLine;
        debugText += "ThrowVelocityBoostScale = " + LinkedPickup.ThrowVelocityBoostScale + newLine;
        debugText += "pickupable = " + LinkedPickup.pickupable + newLine;
        debugText += "proximity = " + LinkedPickup.proximity + newLine;

        DebugField.text = debugText;
    }

    public override void OnPickup()
    {
        LinkedPickup.GenerateHapticEvent(duration: 0.25f, amplitude: 0.5f, frequency: 0.5f);
    }

    public override void OnPickupUseDown()
    {
        LocalToggle.SetActive(true);
    }

    public override void OnPickupUseUp()
    {
        LocalToggle.SetActive(false);
    }
}