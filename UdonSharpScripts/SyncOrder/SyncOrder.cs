
using Newtonsoft.Json.Linq;
using System.Runtime.Remoting.Messaging;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)    ]
public class SyncOrder : UdonSharpBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI LogOutput;

    [UdonSynced, FieldChangeCallback(nameof(syncChanged))] float randomValue = 0;

    bool updateCalled = false;
    bool fixedUpdateCalled = false;

    private void Awake()
    {
        addText("Awake called");
    }

    void Start()
    {
        addText("Start called");

        if (Networking.LocalPlayer.playerId == 1)
        {
            randomValue = Random.value;
            RequestSerialization();
        }
    }

    private void Update()
    {
        if (!updateCalled)
        {
            addText("First update called");
            updateCalled = true;
        }
    }

    private void FixedUpdate()
    {
        if (!fixedUpdateCalled)
        {
            addText("First fixed update called");
            fixedUpdateCalled = true;
        }
    }

    public override void OnPreSerialization()
    {
        addText("Pre-serialization called");
    }

    public override void OnDeserialization()
    {
        addText("Deserialization called");
    }

    public override void OnOwnershipTransferred(VRCPlayerApi player)
    {
        addText("Ownership transfer called");
    }

    void addText(string text)
    {
        string ownerString = Networking.GetOwner(gameObject).playerId.ToString();

        if (Networking.IsOwner(gameObject))
        {
            ownerString += " (You)";
        }
        else
        {
            ownerString += " (Else)";
        }

        LogOutput.text += $"{currentTime}: {text} with random value = {randomValue}, Owner: {ownerString}\n";
    }

    public float syncChanged
    {
        get => randomValue;
        set
        {
            randomValue = value;
            addText("Callback called");
        }
    }

    string text
    {
        get
        {
            return LogOutput.text;
        }
        set
        {
            LogOutput.text += $"{currentTime}: {value} with random value = {randomValue}\n";
        }
    }

    float currentTime
    {
        get
        {
            return Time.time;
        }
    }
}
