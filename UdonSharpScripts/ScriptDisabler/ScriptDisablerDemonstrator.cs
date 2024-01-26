using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class ScriptDisablerDemonstrator : UdonSharpBehaviour
    {
        [SerializeField] ScriptDisablerInstance DisableInstance;
        [SerializeField] TMPro.TextMeshProUGUI infoBox;

        const string newLine = "\n";

        private void Update()
        {
            string outputText = "";

            outputText += "Time.time = " + Time.time + newLine;
            outputText += "IsOwner of script = " + Networking.IsOwner(DisableInstance.gameObject) + newLine;
            outputText += "Script is enabled = " + DisableInstance.enabled + newLine;
            outputText += "syncedTime = " + DisableInstance.syncedTime + newLine;

            infoBox.text = outputText;
        }

        void TakeOwnership()
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, nameof(EnableExternal));
            DisableInstance.enabled = true;
            Networking.SetOwner(player: Networking.LocalPlayer, obj: DisableInstance.gameObject);
        }

        public void EnableExternal()
        {
            if (Networking.IsOwner(DisableInstance.gameObject)) DisableInstance.enabled = true;
        }

        public void ToogleScript()
        {
            DisableInstance.enabled = !DisableInstance.enabled;
        }
    }
}