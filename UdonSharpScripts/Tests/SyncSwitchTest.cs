
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SyncSwitchTest : UdonSharpBehaviour
{
    [SerializeField] GameObject[] indicators;
    [SerializeField] GameObject pressIndicator;
    [SerializeField] GameObject syncIndicator;

    //[UdonSynced] int state = 0;
    int state = 0;

    void Start()
    {
        
    }

    void IncreaseState()
    {
        state++;

        if (state == indicators.Length) state = 0;

        syncIndicator.SetActive(!pressIndicator.activeSelf);
    }

    private void Update()
    {
        foreach(GameObject indicator in indicators)
        {
            indicator.SetActive(false);
        }

        indicators[state].SetActive(true);
    }

    public override void Interact()
    {
        //Networking.SetOwner(Networking.LocalPlayer, gameObject);

        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(IncreaseState));

        //IncreaseState();
        pressIndicator.SetActive(!pressIndicator.activeSelf);
    }

    /*
    public override void Interact()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);

        state++;

        if (state == indicators.Length) state = 0;

        pressIndicator.SetActive(!pressIndicator.activeSelf);
    }
    */
}
