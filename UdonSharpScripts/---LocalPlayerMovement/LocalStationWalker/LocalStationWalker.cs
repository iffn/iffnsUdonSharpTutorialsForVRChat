using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

[UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]
public class LocalStationWalker : UdonSharpBehaviour
{
    //Asignment variables
    [SerializeField] Transform LinkedPlayerController;
    [SerializeField] Transform VisualRepresentation;
    [SerializeField] Transform CollisionRepresentation;
    [SerializeField] Transform PlayerSeatTransform;
    [SerializeField] VRCStation PlayerStation;

    [UdonSynced(UdonSyncMode.Smooth)] Vector3 LocalSeatPosition;

    //Debug
    [SerializeField] TMPro.TextMeshProUGUI InfoBox;

    //newLine = backslash n which is interpreted as a new line when showing the code in a text field
    string newLine = "\n";

    //Runtime variables
    bool activeSeat = false;
    float horizontalValue = 0;
    float verticalValue = 0;
    Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = LinkedPlayerController.GetComponent<Rigidbody>();
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player != Networking.LocalPlayer) return;

        transform.GetComponent<MeshRenderer>().material.color = Color.red;

        activeSeat = true;

        PlayerSeatTransform.transform.position = player.GetPosition();
        PlayerSeatTransform.transform.rotation = player.GetRotation();

        LinkedPlayerController.localPosition = PlayerSeatTransform.localPosition;
        LinkedPlayerController.localRotation = PlayerSeatTransform.localRotation;

        Networking.SetOwner(Networking.LocalPlayer, PlayerSeatTransform.gameObject);

        PlayerStation.UseStation(player: Networking.LocalPlayer);
        //player.Immobilize(true);
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (player != Networking.LocalPlayer) return;

        if (activeSeat)
        {
            ExitStation();
        }
        
        //Networking.LocalPlayer.Immobilize(false);
    }

    void ExitStation()
    {
        PlayerStation.ExitStation(player: Networking.LocalPlayer);

        activeSeat = false;

        transform.GetComponent<MeshRenderer>().material.color = Color.yellow;

        Networking.LocalPlayer.Immobilize(false);
    }

    int frameCounter = 0;


    private void Update()
    {
        frameCounter++;

        string outputText = "";

        if (Networking.IsOwner(PlayerSeatTransform.gameObject))
        {
            if (!activeSeat) return;

            Vector3 heading = Networking.LocalPlayer.GetBoneRotation(HumanBodyBones.Head) * Vector3.forward;
            heading = new Vector3(heading.x, 0, heading.z);
            Quaternion newRotation = Quaternion.LookRotation(heading, Vector3.up);

            if (frameCounter%5 == 0)
            {
                //Rotate seat to head heading
                PlayerSeatTransform.rotation = newRotation;

                //Reseat
                PlayerStation.ExitStation(player: Networking.LocalPlayer);
                PlayerStation.UseStation(player: Networking.LocalPlayer);
            }
            
            //PlayerSeatTransform.rotation = ;

            //Apply rotation to linked player controller
            LinkedPlayerController.localRotation = PlayerSeatTransform.localRotation;

            //Get seat position from linked player controller
            PlayerSeatTransform.localPosition = LinkedPlayerController.localPosition;

            //Check if exit conditions are met
            if (LinkedPlayerController.transform.localPosition.z < -1.25f || LinkedPlayerController.transform.localPosition.y < -0.1f)
            {
                ExitStation();
            }

            //Synchronize local seat position
            LocalSeatPosition = PlayerSeatTransform.localPosition;

            outputText += "Heading before: " + heading + newLine;
            outputText += "newRotation before: " + newRotation.eulerAngles.y + newLine;

            heading = Networking.LocalPlayer.GetBoneRotation(HumanBodyBones.Head) * Vector3.forward;
            heading = new Vector3(heading.x, 0, heading.z);
            Quaternion newRotationafter = Quaternion.LookRotation(heading, Vector3.up);

            outputText += "Heading after: " + heading + newLine;
            outputText += "newRotation after: " + newRotationafter.eulerAngles.y + newLine;
            outputText += "newRotation difference: " + (newRotationafter.eulerAngles.y - newRotation.eulerAngles.y) + newLine;

            Vector3 headHeading = Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).rotation * Vector3.forward;
            Quaternion headRotation = Quaternion.LookRotation(heading, Vector3.up);

            outputText += "Head heading: " + headHeading + newLine;
            outputText += "Head rotation: " + headRotation.eulerAngles.y + newLine;
        }
        else
        {
            PlayerSeatTransform.localPosition = LocalSeatPosition;
        }

        InfoBox.text = outputText;

        //Networking.LocalPlayer.TeleportTo(PlayerPositionTransformer.position, PlayerPositionTransformer.rotation, VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint, lerpOnRemote: true);
    }

    private void FixedUpdate()
    {
        if (!activeSeat) return;

        LinkedPlayerController.Translate(new Vector3(horizontalValue * Time.fixedDeltaTime, 0, verticalValue * Time.fixedDeltaTime));

        //Networking.LocalPlayer.SetVelocity(playerRigidbody.velocity);
    }

    public override void InputMoveHorizontal(float value, VRC.Udon.Common.UdonInputEventArgs args)
    {
        horizontalValue = value;
    }

    public override void InputMoveVertical(float value, VRC.Udon.Common.UdonInputEventArgs args)
    {
        verticalValue = value;
    }

    public override void InputJump(bool value, UdonInputEventArgs args)
    {
        if(value == true && activeSeat)
        {
            ExitStation();
        }
    }
}
