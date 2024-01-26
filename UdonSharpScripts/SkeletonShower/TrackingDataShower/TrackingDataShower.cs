
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TrackingDataShower : UdonSharpBehaviour
{
    [SerializeField] Transform RightHandCoordinateSystem;
    [SerializeField] Transform LeftHandCoordinateSystem;

    void Update()
    {
        VRCPlayerApi.TrackingData rightHand = Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.RightHand);
        VRCPlayerApi.TrackingData leftHand = Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.LeftHand);

        RightHandCoordinateSystem.SetPositionAndRotation(rightHand.position, rightHand.rotation);
        LeftHandCoordinateSystem.SetPositionAndRotation(leftHand.position, leftHand.rotation);
    }
}
