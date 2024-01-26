
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class PlayerRotationMeasurement : UdonSharpBehaviour
{
    [SerializeField] LineRenderer LinkedAngleDisplay;
    [SerializeField] InputField LinkedOutputField;

    Quaternion lastRotation;
    bool rotatedLastFrame = false;
    int lastIndex = 0;

    private void Start()
    {
        LinkedAngleDisplay.positionCount = 361;

        for(int i = 0; i<361; i++)
        {
            LinkedAngleDisplay.SetPosition(i, new Vector3(i, -50, 0));
        }
    }

    private void Update()
    {
        //Evaluate joystick
        float x = Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickHorizontal");
        float y = Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickVertical");

        Vector2 inputs = new Vector2(x, y);

        if(inputs.magnitude > 0.5f)
        {
            if (rotatedLastFrame)
            {
                //Calculate speed
                Quaternion rotationn = Networking.LocalPlayer.GetRotation();
                float speed = Quaternion.Angle(rotationn, lastRotation) / Time.deltaTime;

                //Calculate joystick angle index
                float angleDeg = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
                if (angleDeg < 0) angleDeg += 360;
                int angleIndex = Mathf.RoundToInt(angleDeg);

                //Apply to line output
                LinkedAngleDisplay.SetPosition(lastIndex, new Vector3(lastIndex, speed, 0));

                //Save rotation for next iteration;
                lastRotation = rotationn;
                lastIndex = angleIndex;
            }

            rotatedLastFrame = true;
        }
        else
        {
            rotatedLastFrame = false;
        }
    }

    public void OutputValues()
    {
        string outputString = "Angle [°]\tValue\n";

        for(int i = 0; i<LinkedAngleDisplay.positionCount; i++)
        {
            outputString += $"{i}\t{LinkedAngleDisplay.GetPosition(i).y}\n";
        }

        LinkedOutputField.text = outputString;
    }
}
