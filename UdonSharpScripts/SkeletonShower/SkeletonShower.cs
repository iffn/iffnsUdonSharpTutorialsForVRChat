using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace iffnsStuff.iffnsVRCStuff
{
    public class SkeletonShower : UdonSharpBehaviour
    {
        [SerializeField] GameObject boneTempalte;

        Transform[] bones;

        string[] boneNames = new string[]
        {
            "Hips",
            "LeftUpperLeg",
            "RightUpperLeg",
            "LeftLowerLeg",
            "RightLowerLeg",
            "LeftFoot",
            "RightFoot",
            "Spine",
            "Chest",
            "UpperChest",
            "Neck",
            "Head",
            "LeftShoulder",
            "RightShoulder",
            "LeftUpperArm",
            "RightUpperArm",
            "LeftLowerArm",
            "RightLowerArm",
            "LeftHand",
            "RightHand",
            "LeftToes",
            "RightToes",
            "LeftEye",
            "RightEye",
            "Jaw",
            "LeftThumbProximal",
            "LeftThumbIntermediate",
            "LeftThumbDistal",
            "LeftIndexProximal",
            "LeftIndexIntermediate",
            "LeftIndexDistal",
            "LeftMiddleProximal",
            "LeftMiddleIntermediate",
            "LeftMiddleDistal",
            "LeftRingProximal",
            "LeftRingIntermediate",
            "LeftRingDistal",
            "LeftLittleProximal",
            "LeftLittleIntermediate",
            "LeftLittleDistal",
            "RightThumbProximal",
            "RightThumbIntermediate",
            "RightThumbDistal",
            "RightIndexProximal",
            "RightIndexIntermediate",
            "RightIndexDistal",
            "RightMiddleProximal",
            "RightMiddleIntermediate",
            "RightMiddleDistal",
            "RightRingProximal",
            "RightRingIntermediate",
            "RightRingDistal",
            "RightLittleProximal",
            "RightLittleIntermediate",
            "RightLittleDistal",
            "LastBone"
        };

        /*
        HumanBodyBones[] boneTypes = new HumanBodyBones[]
        {
            HumanBodyBones.Hips,
            HumanBodyBones.LeftUpperLeg,
            HumanBodyBones.RightUpperLeg,
            HumanBodyBones.LeftLowerLeg,
            HumanBodyBones.RightLowerLeg,
            HumanBodyBones.LeftFoot,
            HumanBodyBones.RightFoot,
            HumanBodyBones.Spine,
            HumanBodyBones.Chest,
            HumanBodyBones.UpperChest,
            HumanBodyBones.Neck,
            HumanBodyBones.Head,
            HumanBodyBones.LeftShoulder,
            HumanBodyBones.RightShoulder,
            HumanBodyBones.LeftUpperArm,
            HumanBodyBones.RightUpperArm,
            HumanBodyBones.LeftLowerArm,
            HumanBodyBones.RightLowerArm,
            HumanBodyBones.LeftHand,
            HumanBodyBones.RightHand,
            HumanBodyBones.LeftToes,
            HumanBodyBones.RightToes,
            HumanBodyBones.LeftEye,
            HumanBodyBones.RightEye,
            HumanBodyBones.Jaw,
            HumanBodyBones.LeftThumbProximal,
            HumanBodyBones.LeftThumbIntermediate,
            HumanBodyBones.LeftThumbDistal,
            HumanBodyBones.LeftIndexProximal,
            HumanBodyBones.LeftIndexIntermediate,
            HumanBodyBones.LeftIndexDistal,
            HumanBodyBones.LeftMiddleProximal,
            HumanBodyBones.LeftMiddleIntermediate,
            HumanBodyBones.LeftMiddleDistal,
            HumanBodyBones.LeftRingProximal,
            HumanBodyBones.LeftRingIntermediate,
            HumanBodyBones.LeftRingDistal,
            HumanBodyBones.LeftLittleProximal,
            HumanBodyBones.LeftLittleIntermediate,
            HumanBodyBones.LeftLittleDistal,
            HumanBodyBones.RightThumbProximal,
            HumanBodyBones.RightThumbIntermediate,
            HumanBodyBones.RightThumbDistal,
            HumanBodyBones.RightIndexProximal,
            HumanBodyBones.RightIndexIntermediate,
            HumanBodyBones.RightIndexDistal,
            HumanBodyBones.RightMiddleProximal,
            HumanBodyBones.RightMiddleIntermediate,
            HumanBodyBones.RightMiddleDistal,
            HumanBodyBones.RightRingProximal,
            HumanBodyBones.RightRingIntermediate,
            HumanBodyBones.RightRingDistal,
            HumanBodyBones.RightLittleProximal,
            HumanBodyBones.RightLittleIntermediate,
            HumanBodyBones.RightLittleDistal,
            HumanBodyBones.LastBone
        };
        */

        void Start()
        {
            bones = new Transform[boneNames.Length];

            for(int i = 0; i< boneNames.Length; i++)
            {
                Transform newBone = VRCInstantiate(original: boneTempalte).transform;

                bones[i] = newBone;

                //newBone.GetChild(0).GetComponent<TMPro.TMP_Text>().text = boneNames[i];
            }
        }

        void SetBonePosition(HumanBodyBones bone, Vector3 offset)
        {
            if (i > bones.Length) return;


            if (Networking.LocalPlayer.GetBonePosition(bone) == null) return;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;
        }

        int i;

        private void Update()
        {
            if (Networking.LocalPlayer == null) return;

            Vector3 offset = -Networking.LocalPlayer.GetPosition() + transform.position;

            i = 0;

            SetBonePosition(bone: HumanBodyBones.Head, offset: offset);

            /*
            SetBonePosition(bone: HumanBodyBones.Hips, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftUpperLeg, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightUpperLeg, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftLowerLeg, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightLowerLeg, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftFoot, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightFoot, offset: offset);
            SetBonePosition(bone: HumanBodyBones.Spine, offset: offset);
            SetBonePosition(bone: HumanBodyBones.Chest, offset: offset);
            SetBonePosition(bone: HumanBodyBones.UpperChest, offset: offset);
            SetBonePosition(bone: HumanBodyBones.Neck, offset: offset);
            SetBonePosition(bone: HumanBodyBones.Head, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftShoulder, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightShoulder, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftUpperArm, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightUpperArm, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftLowerArm, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightLowerArm, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftHand, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightHand, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftToes, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightToes, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftEye, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightEye, offset: offset);
            SetBonePosition(bone: HumanBodyBones.Jaw, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftThumbProximal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftThumbIntermediate, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftThumbDistal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftIndexProximal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftIndexIntermediate, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftIndexDistal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftMiddleProximal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftMiddleIntermediate, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftMiddleDistal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftRingProximal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftRingIntermediate, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftRingDistal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftLittleProximal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftLittleIntermediate, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LeftLittleDistal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightThumbProximal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightThumbIntermediate, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightThumbDistal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightIndexProximal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightIndexIntermediate, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightIndexDistal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightMiddleProximal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightMiddleIntermediate, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightMiddleDistal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightRingProximal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightRingIntermediate, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightRingDistal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightLittleProximal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightLittleIntermediate, offset: offset);
            SetBonePosition(bone: HumanBodyBones.RightLittleDistal, offset: offset);
            SetBonePosition(bone: HumanBodyBones.LastBone, offset: offset);
            */

            /*
            HumanBodyBones bone;

            bone = HumanBodyBones.Hips;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftUpperLeg;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightUpperLeg;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftLowerLeg;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightLowerLeg;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftFoot;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightFoot;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.Spine;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.Chest;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.UpperChest;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.Neck;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.Head;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftShoulder;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightShoulder;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftUpperArm;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightUpperArm;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftLowerArm;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightLowerArm;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftHand;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightHand;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftToes;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightToes;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftEye;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightEye;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.Jaw;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftThumbProximal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftThumbIntermediate;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftThumbDistal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftIndexProximal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftIndexIntermediate;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftIndexDistal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftMiddleProximal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftMiddleIntermediate;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftMiddleDistal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftRingProximal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftRingIntermediate;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftRingDistal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftLittleProximal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftLittleIntermediate;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LeftLittleDistal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightThumbProximal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightThumbIntermediate;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightThumbDistal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightIndexProximal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightIndexIntermediate;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightIndexDistal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightMiddleProximal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightMiddleIntermediate;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightMiddleDistal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightRingProximal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightRingIntermediate;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightRingDistal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightLittleProximal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightLittleIntermediate;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.RightLittleDistal;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;

            bone = HumanBodyBones.LastBone;
            bones[i].position = Networking.LocalPlayer.GetBonePosition(bone) + offset;
            bones[i].rotation = Networking.LocalPlayer.GetBoneRotation(bone);
            i++;
            */

        }
    }
}