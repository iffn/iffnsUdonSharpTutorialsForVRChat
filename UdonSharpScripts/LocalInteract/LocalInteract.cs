using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class LocalInteract : UdonSharpBehaviour
    {
        [SerializeField] GameObject ToggleObject;

        public override void Interact()
        {
            ToggleObject.SetActive(!ToggleObject.activeSelf);
        }
    }
}