using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpamTeleportController : UdonSharpBehaviour
{
    //Asignment variables
    [SerializeField] Transform LinkedPlayerController;
    [SerializeField] Transform VisualRepresentation;
    [SerializeField] Transform CollisionRepresentation;
    [SerializeField] Transform PlayerPositionTransformer;

    //Fixed variables

    //Runtime variables
    bool activeTeleport = false;
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

        activeTeleport = true;

        PlayerPositionTransformer.transform.position = player.GetPosition();
        PlayerPositionTransformer.transform.rotation = player.GetRotation();

        LinkedPlayerController.localPosition = PlayerPositionTransformer.localPosition;
        LinkedPlayerController.localRotation = PlayerPositionTransformer.localRotation;

        //player.Immobilize(true);
        //Networking.LocalPlayer.SetGravityStrength(1);
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (player != Networking.LocalPlayer) return;

        activeTeleport = false;
        //Networking.LocalPlayer.Immobilize(false);
        //Networking.LocalPlayer.SetGravityStrength(0);
    }

    private void Update()
    {
        if (!activeTeleport) return;

        PlayerPositionTransformer.transform.rotation = Networking.LocalPlayer.GetRotation();

        LinkedPlayerController.localRotation = PlayerPositionTransformer.localRotation;

        PlayerPositionTransformer.localPosition = LinkedPlayerController.localPosition;

        if (LinkedPlayerController.transform.localPosition.z < -1.25f ||LinkedPlayerController.transform.localPosition.y < 0.1f)
        {
            
        }

        Networking.LocalPlayer.TeleportTo(PlayerPositionTransformer.position, PlayerPositionTransformer.rotation, VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint, lerpOnRemote: true);
    }

    private void FixedUpdate()
    {
        if (!activeTeleport) return;

        LinkedPlayerController.Translate(new Vector3(horizontalValue * Time.fixedDeltaTime, 0, verticalValue * Time.fixedDeltaTime));

        Networking.LocalPlayer.SetVelocity(playerRigidbody.velocity);
    }

    public override void InputMoveHorizontal(float value, VRC.Udon.Common.UdonInputEventArgs args)
    {
        horizontalValue = value;
    }

    public override void InputMoveVertical(float value, VRC.Udon.Common.UdonInputEventArgs args)
    {
        verticalValue = value;
    }
}
