using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Continuous)]
    public class ScriptDisablerInstance : UdonSharpBehaviour
    {
        [HideInInspector] [UdonSynced] public float syncedTime;

        void Start()
        {

        }

        private void Update()
        {
            if(Networking.IsOwner(gameObject)) syncedTime = Time.time;
        }
    }
}