
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]
public class StandingSeatController : UdonSharpBehaviour
{
    //Asignment variables
    [SerializeField] Transform CoordinateTransform;
    [SerializeField] Transform SeatTransform;
    [SerializeField] VRCStation PlayerStation;

    [UdonSynced(UdonSyncMode.Smooth)] float SeatRoration;

    //Debug
    [SerializeField] TMPro.TextMeshProUGUI InfoBox;

    //newLine = backslash n which is interpreted as a new line when showing the code in a text field
    //string newLine = "\n";

    //Runtime variables
    bool activeSeat = false;
    float horizontalValue = 0;
    float verticalValue = 0;
    Rigidbody playerRigidbody;

    void Start()
    {
        
    }

    public override void Interact()
    {
        activeSeat = true;

        Networking.SetOwner(Networking.LocalPlayer, SeatTransform.gameObject);

        PlayerStation.UseStation(player: Networking.LocalPlayer);
    }

    Quaternion GetNormalizedHeadRotation()
    {
        Vector3 heading = Networking.LocalPlayer.GetBoneRotation(HumanBodyBones.Head) * Vector3.forward;
        heading = new Vector3(heading.x, 0, heading.z);
        Quaternion newRotation = Quaternion.LookRotation(heading, Vector3.up);

        return newRotation;
    }

    void RotateSeat()
    {
        //Step 0
        newRotation = GetNormalizedHeadRotation();
        SeatTransform.rotation = Quaternion.identity;
        //Step 1
        PlayerStation.ExitStation(player: Networking.LocalPlayer);
        //Step 2
        PlayerStation.UseStation(player: Networking.LocalPlayer);
        //Step 3
        SeatTransform.rotation = newRotation;
    }

    void ExitStation()
    {
        PlayerStation.ExitStation(player: Networking.LocalPlayer);

        activeSeat = false;

        Networking.LocalPlayer.Immobilize(false);

        stepState = 0;
        stepDone = false;
        forwardActive = false;
    }

    int frameCounter = 0;

    private void Update()
    {
        frameCounter++;

        string outputText = "";

        CoordinateTransform.rotation = GetNormalizedHeadRotation();

        if (activeSeat && activateRotation)
        {
            
            if (frameCounter % 5 == 0)
            {
                RotateSeat();
            }
        }

        InfoBox.text = outputText;
    }

    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        if (!activeSeat) return;

        
    }

    int stepState = 0;
    bool stepDone = false;

    Quaternion newRotation;

    public override void InputMoveHorizontal(float value, VRC.Udon.Common.UdonInputEventArgs args)
    {
        horizontalValue = value;

        if (!activeSeat) return;

        if (!stepDone)
        {
            if (value > 0.8f)
            {
                stepDone = true;

                switch (stepState)
                {
                    case 0:
                        newRotation = GetNormalizedHeadRotation();
                        SeatTransform.rotation = Quaternion.identity;
                        stepState++;
                        break;
                    case 1:
                        PlayerStation.ExitStation(player: Networking.LocalPlayer);
                        //Networking.LocalPlayer.Immobilize(true);
                        stepState++;
                        break;
                    case 2:
                        //Networking.LocalPlayer.TeleportTo(Networking.LocalPlayer.GetPosition(), Quaternion.identity);
                        PlayerStation.UseStation(player: Networking.LocalPlayer);
                        stepState++;
                        break;
                    case 3:
                        SeatTransform.rotation = newRotation;
                        stepState = 0;
                        break;
                }

            }
        }
        else
        {
            if (value < 0.5f)
            {
                stepDone = false;
            }
        }
    }

    bool activateRotation = false;

    bool forwardActive = false;
    public override void InputMoveVertical(float value, VRC.Udon.Common.UdonInputEventArgs args)
    {
        verticalValue = value;

        if (!activeSeat) return;

        if (!forwardActive)
        {
            if(value > 0.8f)
            {
                forwardActive = true;
                activateRotation = !activateRotation;
                //RotateSeat();
            }
        }
        else
        {
            if(value < 0.5f)
            {
                forwardActive = false;
            }
        }
    }


    public override void InputJump(bool value, VRC.Udon.Common.UdonInputEventArgs args)
    {
        if (value == true && activeSeat)
        {
            ExitStation();
        }
    }
}
