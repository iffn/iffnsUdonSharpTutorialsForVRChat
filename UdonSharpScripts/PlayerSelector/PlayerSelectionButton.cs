using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class PlayerSelectionButton : UdonSharpBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI title;

        public VRCPlayerApi player;

        PlayerSelector linkedPlayerSelector;

        public void Setup(VRCPlayerApi player, PlayerSelector linkedPlayerSelector)
        {
            this.player = player;
            this.linkedPlayerSelector = linkedPlayerSelector;
            title.text = $"{player.playerId}: {player.displayName}";
        }

        public void SelectPlayer()
        {
            linkedPlayerSelector.SelectPlayer(player);
        }
    }
}