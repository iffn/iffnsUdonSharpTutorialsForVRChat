
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using iffnsStuff.iffnsVRCStuff.DebugOutput;

public class SyncControllerDemoSettings : UdonSharpBehaviour
{
    [SerializeField] SingleScriptDebugState LinkedStateOutput;
    [SerializeField] Slider LinkedSlider;
    [SerializeField] TMPro.TextMeshProUGUI TitleText;
    [SerializeField] string MainTitle = "Time between updates target";


    void UpdateValuesFromSlider()
    {
        float slideValue = LinkedSlider.value;

        TitleText.text = MainTitle + " = " + slideValue + "s";
        LinkedStateOutput.TimeBetweenOutputs = slideValue;
    }

    private void Start()
    {
        UpdateValuesFromSlider();
    }

    public override void Interact()
    {
        UpdateValuesFromSlider();
    }
    
}
