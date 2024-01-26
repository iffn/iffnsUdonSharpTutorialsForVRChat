
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;

[UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)] //Note: Continuous is not an efficient way to sync this
public class SyncedInteractSimple : UdonSharpBehaviour
{
    [UdonSynced] bool ShouldBeActive = true;

    [SerializeField] GameObject ToggleObject;

    [SerializeField] TMPro.TextMeshPro infoBox;
    int numberOfDeserializations = 0;
    int numberOfBytes = 0;

    //newLine = backslash n which is interpreted as a new line when showing the code in a text field
    string newLine = "\n";

    public override void Interact()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        ShouldBeActive = !ShouldBeActive;

        ToggleObject.SetActive(ShouldBeActive);
    }

    int numberOfSuccesses = 0;
    int numberOfFailures = 0;
    int lastByteCount = 0;

    public override void OnDeserialization()
    {
        ToggleObject.SetActive(ShouldBeActive);

        numberOfDeserializations++;
    }
    
    public override void OnPostSerialization(SerializationResult result)
    {
        if (result.success) numberOfSuccesses++;
        else numberOfFailures++;
        lastByteCount = result.byteCount;
        numberOfBytes += result.byteCount;
    }

    private void Update()
    {
        string outputText = "";

        outputText += "Owner = " + Networking.GetOwner(obj: gameObject).displayName + newLine;
        outputText += "Number of Deserializations = " + numberOfDeserializations + newLine;
        outputText += "Number of successes = " + numberOfSuccesses + newLine;
        outputText += "Number of failures = " + numberOfFailures + newLine;
        outputText += "Last byte count = " + lastByteCount + newLine;
        outputText += "Complete byte count = " + numberOfBytes + newLine;

        infoBox.text = outputText;
    }
}
