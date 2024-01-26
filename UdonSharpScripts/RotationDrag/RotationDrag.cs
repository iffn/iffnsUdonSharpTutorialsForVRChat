
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]
public class RotationDrag : UdonSharpBehaviour
{
    [SerializeField] Transform MovingObject;
    [SerializeField] float minAngle = 0;
    [SerializeField] float maxAngle = 90;
    [SerializeField] VRC.SDK3.Components.VRCPickup Pickup;
    [SerializeField] Collider[] DisableCollider;
    [SerializeField] Transform InteractorRestingLocation;

    [SerializeField] TMPro.TextMeshProUGUI DebugField;
    string newLine = "\n";

    [UdonSynced(networkSyncTypeIn: UdonSyncMode.Linear)] float currentAngle;


    void Start()
    {
        if (Networking.IsOwner(Networking.LocalPlayer, MovingObject.gameObject))
        {
            currentAngle = MovingObject.rotation.eulerAngles.y;
        }

        if(minAngle > maxAngle)
        {
            float tempMax = maxAngle;
            maxAngle = minAngle;
            minAngle = tempMax;
        }

        if (Networking.LocalPlayer.IsUserInVR())
        {
            Pickup.proximity = 0.05f;
        }
        else
        {
            Pickup.proximity = 0.4f;
        }
    }

    float CalculateAnlge(Vector3 targetPosLocal)
    {
        float x = targetPosLocal.x;
        float z = targetPosLocal.z;

        float angle = Mathf.Atan2(z, x) * Mathf.Rad2Deg;

        if (angle > 180) angle -= 360;
        
        return angle;
    }

    void SetColliderState(bool newState)
    {
        foreach(Collider currentCollider in DisableCollider)
        {
            currentCollider.enabled = newState;
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

            SetColliderState(false);

            if (Pickup.currentPlayer == Networking.LocalPlayer)
            {
                Networking.SetOwner(Networking.LocalPlayer, gameObject);

                currentAngle = CalculateAnlge(Pickup.transform.localPosition);

                debugText += "unlamped rotation: " + currentAngle + newLine;

                currentAngle = Mathf.Clamp(value: currentAngle, min: minAngle, max: maxAngle);

                debugText += "Clamped rotation: " + currentAngle + newLine;

                SetRotation();

                RequestSerialization();
            }
        }
        else 
        {
            if (Networking.IsOwner(Pickup.gameObject))
            {
                Pickup.transform.position = InteractorRestingLocation.position;
                Pickup.transform.rotation = InteractorRestingLocation.rotation;
                debugText += "Resetting position" + newLine;
            }

            SetColliderState(true);
        }

        DebugField.text = debugText;
    }

    void SetRotation()
    {
        MovingObject.localRotation = Quaternion.Euler(new Vector3(0, -currentAngle, 0));
    }

    public override void OnDeserialization()
    {
        SetRotation();
    }
}
