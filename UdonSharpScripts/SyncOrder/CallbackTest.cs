
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CallbackTest : UdonSharpBehaviour
{
    [UdonSynced, FieldChangeCallback(nameof(Number))] int number;
    [UdonSynced, FieldChangeCallback(nameof(TimeValue))] float time;

    public int Number
    {
        get
        {
            Debug.Log("Get callback called for Number");
            return number;
        }
        set
        {
            number = value;
            Debug.Log("Number updated to " + number);
        }
    }

    public float TimeValue
    {
        get
        {
            Debug.Log("Get callback called for TimeValue");
            return time;
        }
        set
        {
            time = value;
            Debug.Log("Time updated to" + time);
        }
    }

    public override void Interact()
    {
        number++;
    }

    private void Update()
    {
        if (Networking.IsOwner(gameObject))
        {
            time = Time.time;
        }
    }

    void Start()
    {
        
    }
}
