
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class HelperScripts : UdonSharpBehaviour
{
    public void DisableImmobilize()
    {
        Networking.LocalPlayer.Immobilize(false);
    }
}
