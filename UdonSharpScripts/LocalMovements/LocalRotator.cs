using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class LocalRotator : UdonSharpBehaviour
    {
        [SerializeField] float angularSpeedInDegPerSec = 120f;

        float currentYRotation = 0;

        private void Update()
        {
            currentYRotation += angularSpeedInDegPerSec * Time.deltaTime;

            transform.localRotation = Quaternion.Euler(0, currentYRotation, 0);
        }
    }
}