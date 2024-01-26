using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using iffnsStuff.iffnsVRCStuff.InteractiveControllers;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class RotationDragOutput : UdonSharpBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI OutputTextField;
        [SerializeField] RotationGrabController GrabController;

        private void Update()
        {
            OutputTextField.text = "Current value = " + GrabController.GetOutputValue();
        }
    }
}