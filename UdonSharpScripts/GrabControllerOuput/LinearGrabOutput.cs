using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using iffnsStuff.iffnsVRCStuff.InteractiveControllers;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class LinearGrabOutput : UdonSharpBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI OutputTextField;
        [SerializeField] LinearGrabController GrabController;

        private void Update()
        {
            OutputTextField.text = "Current value = " + GrabController.GetOutputValue();
        }
    }
}