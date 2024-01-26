
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]
public class LinearDrag : UdonSharpBehaviour
{
    [SerializeField] Transform MovingObject;
    [SerializeField] Transform EndPosition;
    [SerializeField] VRC.SDK3.Components.VRCPickup Pickup;

    [SerializeField] TMPro.TextMeshProUGUI DebugField;
    string newLine = "\n";

    Vector3 OriginalPosition;
    [UdonSynced(networkSyncTypeIn: UdonSyncMode.Linear)] float currentZPosition;

    void Start()
    {
        OriginalPosition = MovingObject.position;

        if(Networking.IsOwner(Networking.LocalPlayer, MovingObject.gameObject))
        {
            currentZPosition = MovingObject.position.z;
        }

        if (Networking.LocalPlayer.IsUserInVR())
        {
            //Pickup.proximity = 0.001f;
        }
        else
        {
            //Pickup.proximity = 0.4f;
        }
    }

    private void Update()
    {
        string debugText = "";

        debugText += "Item position: " + Pickup.transform.position + newLine;
        debugText += "Item is held: " + Pickup.IsHeld + newLine;

        if (Pickup.IsHeld)
        {
            debugText += "Current player: " + Pickup.currentPlayer.displayName + newLine;

            if (Pickup.currentPlayer == Networking.LocalPlayer)
            {
                Networking.SetOwner(Networking.LocalPlayer, gameObject);

                currentZPosition = Pickup.transform.position.z;

                float a = OriginalPosition.z;
                float b = EndPosition.position.z;

                currentZPosition = Mathf.Clamp(value: currentZPosition, min: Mathf.Min(a,b), max: Mathf.Max(a,b));

                debugText += "Clamped Z position: " + currentZPosition + newLine;

                SetPostion();

                RequestSerialization();
            }
        }
        else if (Networking.IsOwner(Pickup.gameObject))
        {
            Pickup.transform.position = MovingObject.position;
            debugText += "Resetting position" + newLine;
        }

        DebugField.text = debugText;
    }

    void SetPostion()
    {
        MovingObject.position = new Vector3(MovingObject.position.x, MovingObject.position.y, currentZPosition);
    }

    public override void OnDeserialization()
    {
        SetPostion();
    }

}
