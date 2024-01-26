using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using iffnsStuff.iffnsVRCStuff.SyncControllers;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class SyncControllerDemo : UdonSharpBehaviour
    {
        [SerializeField] Slider LinkedSlider;
        [SerializeField] SyncControllerFloatLinear SyncedFloat;
        [SerializeField] TMPro.TextMeshProUGUI OutputTextField;

        string newLine = "\n";

        float previouslySetValue = 0;

        public override void Interact()
        {
            //Ignore if no value changed since setting the value invokes the linked slider function
            if (LinkedSlider.value == previouslySetValue) return;

            SyncedFloat.SetValue(LinkedSlider.value);
        }

        private void Update()
        {
            string outputText = "";

            if (!Networking.IsOwner(SyncedFloat.gameObject))
            {
                //Save value to detect type of change
                previouslySetValue = SyncedFloat.GetValue();
                LinkedSlider.value = previouslySetValue;
            }

            //LinkedSlider.value = Time.time % 1;

            outputText += "Current value = " + SyncedFloat.GetValue() + newLine;
            outputText += "Time since last sync = " + SyncedFloat.GetTimeSinceLastSync() + newLine;

            outputText += newLine;

            OutputTextField.text = outputText;
        }
    }
}