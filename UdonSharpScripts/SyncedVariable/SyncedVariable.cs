using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]
    public class SyncedVariable : UdonSharpBehaviour
    {
        [SerializeField] Transform movingObjectNone;
        [SerializeField] Transform MovingObjectLinear;
        [SerializeField] Transform MovingObjectSmooth;
        [SerializeField] GameObject PlayerIsOwnerWarning;
        [SerializeField] TMPro.TextMeshProUGUI debugField;
        
        [UdonSynced(UdonSyncMode.None)] Vector3 currentPositionNone;
        [UdonSynced(UdonSyncMode.Linear)] Vector3 currentPositionLinear;
        [UdonSynced(UdonSyncMode.Smooth)] Vector3 currentPositionSmooth;

        Vector3 StartPosition;
        Vector3 TargetPosition;
        float transitionTime = 2;
        float startTime = 0;

        int deserializationCount = 0;
        float previousDeserializationTime = 0;
        float deserializationDeltaTime = 0;
        int byteCount = 0;

        //newLine = backslash n which is interpreted as a new line when showing the code in a text field
        string newLine = "\n";

        private void Start()
        {
            SetNewPosition();
        }

        private void Update()
        {
            PlayerIsOwnerWarning.SetActive(Networking.IsOwner(gameObject));

            if (Networking.IsOwner(gameObject))
            {
                float lerpValue = (Time.time - startTime) / transitionTime;

                if (lerpValue > 1)
                {
                    SetNewPosition();
                }
                else
                {
                    Vector3 position = Vector3.Lerp(a: StartPosition, b: TargetPosition, t: lerpValue);

                    currentPositionNone = position;
                    currentPositionLinear = position;
                    currentPositionSmooth = position;
                }
            }

            SetObjectToCurrentPosition();

            string outputText = "";

            VRCPlayerApi owner = Networking.GetOwner(gameObject);

            outputText += "Owner: " + owner.playerId + ": " + owner.displayName;
            if (owner == Networking.LocalPlayer) outputText += " (You)";
            outputText += newLine;

            outputText += "Deserializations: " + deserializationCount + newLine;
            outputText += "Deserialization delta time = : " + deserializationDeltaTime + newLine;
            outputText += "Position magnitude (Sync mode None): " + currentPositionNone.magnitude + newLine;
            outputText += "Position magnitude (Sync mode Linear): " + currentPositionLinear.magnitude + newLine;
            outputText += "Position magnitude (Sync mode Smooth): " + currentPositionSmooth.magnitude + newLine;
            outputText += "Byte count = : " + byteCount + newLine;

            debugField.text = outputText;
        }

        void SetNewPosition()
        {
            StartPosition = movingObjectNone.localPosition;
            TargetPosition = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            startTime = Time.time;
        }

        void SetObjectToCurrentPosition()
        {
            movingObjectNone.transform.localPosition = currentPositionNone;
            MovingObjectLinear.transform.localPosition = currentPositionLinear;
            MovingObjectSmooth.transform.localPosition = currentPositionSmooth;
        }

        public override void Interact()
        {
            Networking.SetOwner(Networking.LocalPlayer, obj: gameObject);
        }

        public override void OnDeserialization()
        {
            deserializationCount++;

            deserializationDeltaTime = Time.time - previousDeserializationTime;
            previousDeserializationTime = Time.time;
        }

        public override void OnPostSerialization(SerializationResult result)
        {
            byteCount += result.byteCount;
        }
    }
}