using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class ColliderDemo : UdonSharpBehaviour
    {

        [SerializeField] bool move = false;
        [SerializeField] Vector3 offset;
        
        float transitionTime = 2f;

        MeshRenderer Cube;
        Vector3 startPosition;

        private void Start()
        {
            Cube = transform.GetComponent<MeshRenderer>();
            Cube.material.color = Color.white;
            startPosition = transform.localPosition;
        }

        private void Update()
        {
            if (move)
            {
                //Moving the teleporter
                float lerpValue = Time.time % (transitionTime * 2) / transitionTime;
                if (lerpValue > 1) lerpValue = 2 - lerpValue;

                transform.localPosition = Vector3.Lerp(a: startPosition, b: startPosition + offset, t: lerpValue);
            }
        }

        public override void OnPlayerCollisionEnter(VRCPlayerApi player)
        {
            Cube.material.color = Color.blue;
        }

        public override void OnPlayerCollisionStay(VRCPlayerApi player)
        {
            Cube.material.color = Color.blue;
        }

        public override void OnPlayerCollisionExit(VRCPlayerApi player)
        {
            Cube.material.color = Color.cyan;
        }

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            Cube.material.color = Color.red;
        }

        public override void OnPlayerTriggerStay(VRCPlayerApi player)
        {
            Cube.material.color = Color.red;
        }

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            Cube.material.color = Color.yellow;
        }

        public override void OnPlayerParticleCollision(VRCPlayerApi player)
        {

        }
    }
}