using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]
public class FerrisWheelMover : UdonSharpBehaviour
{
    //Asignment variables
    [SerializeField] Transform RotationResetter;
    [SerializeField] bool Moving = true;

    //[UdonSynced] float offsetTime;

    [UdonSynced(UdonSyncMode.Linear)] float angle = 0;
    //[UdonSynced(UdonSyncMode.Smooth)] Vector3 GondolaPosition;

    [SerializeField] TMPro.TextMeshProUGUI InfoBox;

    //newLine = backslash n which is interpreted as a new line when showing the code in a text field
    string newLine = "\n";

    float rotaitonTime = 10f;
    float waitTime = 5f;

    bool waiting = true;
    float lastTime;
    bool setupComplete = false;
    int OnDeserializations = 0;
    int SendOffsetTimes = 0;

    private void Start()
    {
        lastTime = Time.time;

        setupComplete = Networking.GetOwner(gameObject) == Networking.LocalPlayer;
    }

    float actualTime()
    {
        return Time.time;

        /*
        if (Networking.GetOwner(gameObject) == Networking.LocalPlayer)
        {
            return Time.time;
        }
        else
        {
            return Time.time + offsetTime;
        }
        */
    }

    int rotations = 0;

    private void Update()
    {
        string outputText = "";
            
        RotationResetter.rotation = Quaternion.identity;

        if (!Moving) return;

        if (Networking.IsOwner(gameObject))
        {
            if (waiting)
            {
                if (actualTime() > lastTime + waitTime)
                {
                    waiting = false;
                    lastTime = actualTime();
                    angle = rotations * 360;
                }
            }
            else
            {
                float deltaTime = actualTime() - lastTime;

                if (deltaTime > rotaitonTime)
                {
                    waiting = true;
                    transform.rotation = Quaternion.identity;
                    lastTime = actualTime();
                    rotations++;
                    angle = rotations * 360;
                }
                else
                {
                    float lerpValue = deltaTime / rotaitonTime;

                    angle = Mathf.Lerp(a: 0, b: 360, lerpValue) + rotations * 360;
                }
            }

            transform.rotation = Quaternion.Euler(Vector3.back * angle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.back * (angle + angleAddition)) ;
        }

        //outputText += "Offset time: " + offsetTime + newLine;
        outputText += "Is owner: " + Networking.IsOwner(gameObject) + newLine;
        outputText += "Setup complete: " + setupComplete + newLine;
        outputText += "OnDeserializations: " + OnDeserializations + newLine;
        outputText += "SendOffsetTimes: " + SendOffsetTimes + newLine;
        outputText += "angleAddition: " + angleAddition + newLine;
        outputText += "deserializationDeltaTime: " + deserializationDeltaTime + newLine;

        InfoBox.text = outputText;
    }

    float lastAngle = 0;
    float previousDeserializationTime = 0;
    float angleAddition = 0;
    float deserializationDeltaTime = 0;

    public override void OnDeserialization()
    {
        OnDeserializations++;

        previousDeserializationTime = Time.time;

        if (angle % 360 > 0.01f)
        {
            float deserializationDeltaTime = Time.time - previousDeserializationTime;

            angleAddition = angle - lastAngle;

            lastAngle = angle;
        }
        else
        {
            angleAddition = 0;
        }
    }

    /*
    public override void Interact()
    {
        if (Networking.GetOwner(gameObject) == Networking.LocalPlayer)
        {
            SendOffsetTimes++;

            offsetTime = Time.time;

            RequestSerialization();
        }
    }
    */
    /*
    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (Networking.GetOwner(gameObject) == Networking.LocalPlayer)
        {
            SendOffsetTimes++;

            offsetTime = Time.time;

            RequestSerialization();
        }
    }
    */
}
