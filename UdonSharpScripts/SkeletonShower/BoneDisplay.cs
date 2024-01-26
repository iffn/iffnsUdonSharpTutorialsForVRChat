using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class BoneDisplay : UdonSharpBehaviour
    {
        [SerializeField] PlayerSelector LinkedPlayerSelector;
        [SerializeField] HumanBodyBones BoneType;
        [SerializeField] TMPro.TextMeshPro textBox;

        Transform moverTransform; //Follows player. Used to get the local bone positions

        void Start()
        {
            textBox.text = transform.name;
            moverTransform = transform.parent.GetChild(0);
        }

        private void Update()
        {
            //Prevent running in the editor since the ClientSim has no bones :(
#if !UNITY_EDITOR
            VRCPlayerApi player = Networking.LocalPlayer;
            if (LinkedPlayerSelector != null) player = LinkedPlayerSelector.selectedPlayer;

            //Setting up the transform, so that the skeleton alsways stays in the same location and orientation
            moverTransform.position = player.GetPosition();
            moverTransform.rotation = player.GetRotation();

            //Converting the local bone positions to the local skeleton representation location
            //InverseTransformPoint = Transform position from world space to local space
            Vector3 bonePosition = player.GetBonePosition(BoneType);
            Quaternion boneRotation = player.GetBoneRotation(BoneType);

            transform.localPosition = moverTransform.InverseTransformPoint(bonePosition);
            transform.rotation = boneRotation;
#endif
        }
    }
}


/*using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff.Tutorials
{
    public class BoneDisplay : UdonSharpBehaviour
    {
        [SerializeField] PlayerSelector LinkedPlayerSelector;
        [SerializeField] HumanBodyBones BoneType;
        [SerializeField] TMPro.TextMeshPro textBox;

        Transform moverTransform; //Follows player. Used to get the local bone positions

        void Start()
        {
            textBox.text = transform.name;
            moverTransform = transform.parent.GetChild(0);
        }

        private void Update()
        {
            #if !UNITY_EDITOR

            VRCPlayerApi player;
            //if (LinkedPlayerSelector != null && LinkedPlayerSelector.activePlayer != null) player = LinkedPlayerSelector.activePlayer;
            //else player = Networking.LocalPlayer;
            player = Networking.LocalPlayer;

            //Setting up the transform, so that the skeleton alsways stays in the same location and orientation
            transform.SetPositionAndRotation(player.GetPosition(), player.GetRotation());

            //Converting the local bone positions to the local skeleton representation location
            //InverseTransformPoint = Transform position from world space to local space
            Vector3 bonePosition = player.GetBonePosition(BoneType);
            Quaternion boneRotation = player.GetBoneRotation(BoneType);

            Vector3 localBonePosition = transform.InverseTransformPoint(bonePosition);

            transform.localPosition = localBonePosition;
            transform.rotation = boneRotation;

            #endif
        }
    }
}
*/