using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class RespawnCounter : UdonSharpBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI textBox;

        int myRespawnCounter = 0;
        int otherRespawnCounter = 0;


        public override void OnPlayerRespawn(VRCPlayerApi player)
        {
            if (player.isLocal) myRespawnCounter++;
            else otherRespawnCounter++;

            textBox.text = $"My respawn counter: {myRespawnCounter}\n" +
                $"Respawn counter of other players: {otherRespawnCounter}";
        }
    }
}