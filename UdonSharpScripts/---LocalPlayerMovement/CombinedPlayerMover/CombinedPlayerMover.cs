using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class CombinedPlayerMover : UdonSharpBehaviour
    {
        //Asignment variables
        [SerializeField] Transform LinkedPlayerController;
        [SerializeField] Transform VisualRepresentation;
        [SerializeField] Transform CollisionRepresentation;
        [SerializeField] Transform PlayerPositionTransformer;
        [SerializeField] VRCStation PlayerStation;

        [SerializeField] TMPro.TextMeshProUGUI InfoBox;

        //newLine = backslash n which is interpreted as a new line when showing the code in a text field
        string newLine = "\n";

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

            Networking.SetOwner(Networking.LocalPlayer, PlayerStation.gameObject);

            PlayerStation.UseStation(player: Networking.LocalPlayer);

            //SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(StationInteractionUpdate));

            PlayerStation.PlayerMobility = VRCStation.Mobility.Mobile;
        }

        public void StationInteractionUpdate()
        {
            if(!Networking.IsOwner(PlayerStation.gameObject)) PlayerStation.PlayerMobility = VRCStation.Mobility.Immobilize;
        }

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            if (player != Networking.LocalPlayer) return;

            PlayerStation.ExitStation(player: Networking.LocalPlayer);

            activeTeleport = false;
            //Networking.LocalPlayer.Immobilize(false);
            //Networking.LocalPlayer.SetGravityStrength(0);
        }

        private void Update()
        {

            string outputText = "";

            if (activeTeleport)
            {
                PlayerPositionTransformer.transform.rotation = Networking.LocalPlayer.GetRotation();

                LinkedPlayerController.localRotation = PlayerPositionTransformer.localRotation;

                PlayerPositionTransformer.localPosition = LinkedPlayerController.localPosition;

                //Networking.LocalPlayer.TeleportTo(PlayerPositionTransformer.position, PlayerPositionTransformer.rotation, VRC_SceneDescriptor.SpawnOrientation.AlignPlayerWithSpawnPoint, lerpOnRemote: true);
            }
            else
            {
                //PlayerStation.PlayerMobility = VRCStation.Mobility.ImmobilizeForVehicle;
            }

            outputText += "Station owner: " + Networking.IsOwner(PlayerStation.gameObject) + newLine;
            outputText += "Station mobility: " + PlayerStation.PlayerMobility + newLine;

            InfoBox.text = outputText;
        }

        private void FixedUpdate()
        {
            if (!activeTeleport) return;

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
    }
}