
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

public class MobileStationController : UdonSharpBehaviour
{
    [SerializeField] Transform CoordinateTransform;
    [SerializeField] Transform SeatTransform;
    [SerializeField] VRCStation PlayerStation;

    [SerializeField] TMPro.TextMeshProUGUI InfoBox;

    //newLine = backslash n which is interpreted as a new line when showing the code in a text field
    string newLine = "\n";

    bool activeSeat = false;
    void Start()
    {
        
    }

    public override void Interact()
    {
        activeSeat = true;

        Networking.SetOwner(Networking.LocalPlayer, SeatTransform.gameObject);

        PlayerStation.UseStation(player: Networking.LocalPlayer);

        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(StationInteractionUpdate));

        PlayerStation.PlayerMobility = VRCStation.Mobility.Mobile;
    }

    void ExitStation()
    {
        PlayerStation.ExitStation(player: Networking.LocalPlayer);

        activeSeat = false;
    }

    Quaternion GetNormalizedHeadRotation()
    {
        Vector3 heading = Networking.LocalPlayer.GetBoneRotation(HumanBodyBones.Head) * Vector3.forward;
        heading = new Vector3(heading.x, 0, heading.z);
        Quaternion newRotation = Quaternion.LookRotation(heading, Vector3.up);

        return newRotation;
    }

    int frameCounter;

    private void Update()
    {
        frameCounter++;

        string outputText = "";

        CoordinateTransform.rotation = GetNormalizedHeadRotation();

        if (grabValue) SeatTransform.Translate(Vector3.up * Time.deltaTime);

        if (activeSeat)
        {
            

            //Networking.LocalPlayer.TeleportTo(SeatTransform.position, Networking.LocalPlayer.GetRotation(), VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint, lerpOnRemote: true);
        }

        outputText += "Station owner: " + Networking.IsOwner(PlayerStation.gameObject) + newLine;
        outputText += "Station mobility: " + PlayerStation.PlayerMobility + newLine;

        InfoBox.text = outputText;
    }

    public void StationInteractionUpdate()
    {
        PlayerStation.PlayerMobility = VRCStation.Mobility.Immobilize;
    }

    public override void InputDrop(bool value, UdonInputEventArgs args)
    {
        if (value == true && activeSeat)
        {
            ExitStation();
        }
    }

    bool grabValue = false;

    public override void InputGrab(bool value, UdonInputEventArgs args)
    {
        grabValue = value;

        
    }
}
